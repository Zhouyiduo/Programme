using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


//https://www.cnblogs.com/lhg0302/p/4251937.html
namespace TestUiPro
{
    public class ClientPro
    {
        private static byte[] result = new byte[1024];

        public static void SendMessage()
        {
            try
            {
                Socket clientSocket = null;
                IPAddress ip = IPAddress.Parse("127.0.0.1");
                clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                clientSocket.Connect(new IPEndPoint(ip, 8888)); //配置服务器IP与端口 
                string sendStr = "hello!This is a socket test";
                byte[] bs = Encoding.ASCII.GetBytes(sendStr);//把字符串编码为字节  
                clientSocket.Send(bs, bs.Length, 0);//发送信息  

                ///接受从服务器返回的信息  
                //string recvStr = "";
                //byte[] recvBytes = new byte[1024];
                //int bytes;
                //bytes = clientSocket.Receive(recvBytes, recvBytes.Length, 0);//从服务器端接受返回信息  
                //recvStr += Encoding.ASCII.GetString(recvBytes, 0, bytes);

                //form1.Log("client get message" + recvStr);
                //Console.WriteLine("client get message:{0}", recvStr);//显示服务器返回信息  

                clientSocket.Close();

            }
            catch (Exception e)
            {

            }


        }

    }
}
