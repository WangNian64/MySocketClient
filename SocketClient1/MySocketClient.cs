using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace SocketClient1
{
    public class MySocketClient
    {
        public static Socket socketSend;
        private static string ipStr = "127.0.0.1";
        private static int port = 50001;
        public static bool isConnected = false;
        private static MySocketClient mySocketClient;//单例
        private MySocketClient()
        {
            //创建客户端socket连接
            if (socketSend == null)
            {
                ConnectServer(ipStr, port);
            }
        }
        public static MySocketClient GetInstance()
        {
            if (mySocketClient == null)
            {
                mySocketClient = new MySocketClient();
            }
            return mySocketClient;
        }
        //socket连接
        private void ConnectServer(string _ipStr, int _port)
        {
            Close();
            if (isConnected == false)
            {
                try
                {
                    //创建客户端Socket，获得远程ip和端口号
                    socketSend = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    IPAddress ip = IPAddress.Parse(ipStr);
                    //得到远程的IP和Port
                    IPEndPoint point = new IPEndPoint(ip, port);
                    //连接远程的服务器端Socket
                    socketSend.Connect(point);
                    Console.WriteLine("连接成功！");
                    isConnected = true;
                }
                catch (SocketException se)
                {
                    se.ToString();
                    Console.WriteLine("IP或者端口错误");
                }
            }
        }
        //发送信息到socket服务器
        public void SendMessage(string msgSendStr)
        {
            if (isConnected == true && socketSend != null)
            {
                try
                {
                    Console.WriteLine(msgSendStr);
                    ////先进行序列化，存储到内存空间中
                    //MemoryStream ms = new MemoryStream();
                    //BinaryFormatter bf = new BinaryFormatter();
                    //bf.Serialize(ms, msgSendList);
                    ////发送
                    //socketSend.Send(ms.ToArray());
                    byte[] msgBytes = new byte[msgSendStr.Length * 5];
                    msgBytes = Encoding.UTF8.GetBytes(msgSendStr);
                    socketSend.Send(msgBytes);
                }
                catch { }
            }
        }
        //关闭Socket连接
        public void Close()
        {
            if (MySocketClient.socketSend != null && MySocketClient.isConnected == true)
            {
                try
                {
                    MySocketClient.socketSend.Close();
                    mySocketClient = null;
                } catch (SocketException e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
            MySocketClient.isConnected = false;
        }
    }
}
