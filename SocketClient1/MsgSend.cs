using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketClient1
{
    [Serializable]
    //可序列化的发送信息类
    public class MsgSend
    {
        private string deviceName;
        private string goodsName;
        public string DeviceName
        {
            get { return deviceName; }
            set { deviceName = value; }
        }
        public string GoodsName
        {
            get { return goodsName; }
            set { goodsName = value; }
        }
        public MsgSend()
        {

        }
        public MsgSend(string deviceName, string goodsName)
        {
            this.goodsName = goodsName;
            this.deviceName = deviceName;
        }
    }
}
