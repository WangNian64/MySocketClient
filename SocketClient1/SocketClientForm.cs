using System;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO;
namespace SocketClient1
{
    public partial class SocketClientForm : Form
    {
        public SocketClientForm()
        {
            InitializeComponent();
            fileStream = File.Open("F:\\ZhuJunjie\\SocketClient1\\SocketClient1\\MsgSendTable.txt", FileMode.Open);
            streamReader = new StreamReader(fileStream);
            timeInterval = 0.0f;
        }
        public static MySocketClient mySocketClient;

        public FileStream fileStream;
        public StreamReader streamReader;
        public float timeInterval;
        private delegate void showMsgDelegate(string str);
        private void showMsg(string str)
        {
            if (this.textBox_receiveMsg.InvokeRequired)//当调用方和控件不在一个线程中，该值为true，只能用invoke调用
            {
                showMsgDelegate msgDelegate = new showMsgDelegate(showMsg);
                this.textBox_receiveMsg.Invoke(msgDelegate, str);//让控件自己调用委托的方法，线程安全
            } else
            {
                this.textBox_receiveMsg.AppendText(str + "\r\n");
            }
        }
        //点击socket连接按钮
        private void connectBtn_Click(object sender, EventArgs e)
        {
            mySocketClient = MySocketClient.GetInstance();//创建一个socket client连接
            
            //开启新的线程，不停的接收服务器发来的消息
            Thread listenReceiveThread = new Thread(Receiver);
            listenReceiveThread.IsBackground = true;//允许在后台运行
            listenReceiveThread.Start();

            //开启一个自动发送信息的线程,50次/s
            //Thread autoSendMsgThread = new Thread(AutoSendMessage);
            //autoSendMsgThread.IsBackground = true;
            //autoSendMsgThread.Start();
            System.Timers.Timer t = new System.Timers.Timer(2000);//实例化Timer类，设置间隔时间为2000毫秒；
            t.Elapsed += new System.Timers.ElapsedEventHandler(sendAMsg);//到达时间的时候执行事件；
            t.AutoReset = false;//设置是执行一次（false）还是一直执行(true)；
            t.Enabled = true;//是否执行System.Timers.Timer.Elapsed事件；
        }
        //测试：一秒之后直接发一条信息
        public void sendAMsg(object source, System.Timers.ElapsedEventArgs e)
        {
            //场景1
            //string msgSendStr = "Null,Null,Null,Null,CargoFirst|5_6$412$7_8$412$9_10$1$12_13_14$103$15_22$1_1_1_A$|1,Null,Null,Null,Null,Null,Null,Null,Null,Null,Null,Null,Null,Null,Null,Null,Null,Null";//测试1
        
            //string msgSendStr = "Null,Null,Null,Null,Null,Null,CargoFirst|7_8$412$9_10$1$12_13_14$103$15_22$1_1_1_A$|1,Null,Null,Null,Null,Null,Null,Null,Null,Null,Null,Null,Null,Null,Null,Null";//测试2
            string msgSendStr = "Null,Null,Null,CargoFirst|4_5_6$112$8_9$1_1_1_A$|1,Null,Null,Null,Null,Null";//场景2
            mySocketClient.SendMessage(msgSendStr);
            showMsg(msgSendStr);
        }


        //每次自动从txt文件中读取一行发送
        void AutoSendMessage()
        {
            while (true)
            {
                //if (timeListIndex < timeList.Count && (timeInterval - timeList[timeListIndex]) <= 0.0001)
                //{
                //    string msgSendStr = streamReader.ReadLine();
                //    while (msgSendStr != "" && msgSendStr != null)
                //    {
                //        //发送一行消息
                //        mySocketClient.SendMessage(msgSendStr);
                //        showMsg(msgSendStr);
                //        timeListIndex++;
                //    }
                //}
                if (timeInterval - 1.0f <= 0.001f)
                {
                    string msgSendStr = "Null,Null,Null,Null,1_4$112$5_6$412$7_8$412$9_10$1$12_13_14$103$15_22$1_1_1_A$|5_6$412$7_8$412$9_10$1$12_13_14$103$15_22$1_1_1_A$|1,Null,Null,Null,Null,Null,Null,Null,Null,Null,Null,Null,Null,Null,Null,Null,Null,Null,";
                    mySocketClient.SendMessage(msgSendStr);
                    showMsg(msgSendStr);
                }
                timeInterval += 0.02f;
                Console.WriteLine(timeInterval);
                Thread.Sleep(20);
            }
        }
        public void ShowMsg(string msg)
        {
            textBox_receiveMsg.AppendText(msg + "\r\n");
        }
        //接收服务端返回的消息
        void Receiver()
        {
            while (true)
            {
                try
                {
                    byte[] buffer = new byte[1024 * 1024 * 5];
                    //接收的二进制字符，要转换为string
                    int len = MySocketClient.socketSend.Receive(buffer);
                    if (len == 0)
                    {
                        break;
                    }
                    string str = Encoding.UTF8.GetString(buffer, 0, len);
                    Console.WriteLine(MySocketClient.socketSend.RemoteEndPoint + ":" + str);
                }
                catch { }
            }
        }
        //string转list
        //public List<string> msgSendToList(string msgSendStr)
        //{
        //    if (msgSendStr.Length > 0)
        //    {
        //        List<string> msgSendList = new List<string>();
        //        string[] strArr = msgSendStr.Split('|');
        //        int strArrLength = strArr.Length;
        //        for (int i = 0; i < strArrLength;)
        //        {
        //            msgSendList.Add(strArr[i] + ',' + strArr[i + 1]);
        //            i += 2;
        //        }
        //        return msgSendList;
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}
        private void disconnect_btn_Click(object sender, EventArgs e)
        {
            if (mySocketClient != null && MySocketClient.isConnected)
            {
                mySocketClient.Close();
                MySocketClient.isConnected = false;
                showMsg("已断开socket连接！");
            }
        }
        private void clearReceive_btn_Click(object sender, EventArgs e)
        {
            if (textBox_receiveMsg.Text.Length > 0)
            {
                textBox_receiveMsg.Text = "";
            }
        }
        private void listBox_receiveMsg_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void listBox_sendMsg_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void textBox_receiveMsg_TextChanged(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox_IP_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox_sendMsg_TextChanged(object sender, EventArgs e)
        {

        }
        private void SocketClientForm_Load(object sender, EventArgs e)
        {

        }
        
    }
}
