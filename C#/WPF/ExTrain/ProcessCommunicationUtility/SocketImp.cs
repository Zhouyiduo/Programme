using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProcessCommunicationUtility
{
    public class SocketImp
    {
        private bool _isSer = true;
        private static int myProt = 8888;   //端口 
        private Socket serverSocket;
        private subReceive _receiveFun;


        public SocketImp(bool bIsSer, subReceive receiveFun)
        {
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            _isSer = bIsSer;

            if (bIsSer)
            {
                serverSocket.Bind(new IPEndPoint(ip, myProt));  //绑定IP地址：端口 
            }
            else
            {
                serverSocket.Bind(new IPEndPoint(ip, myProt + 1));  //绑定IP地址：端口 
            }
            _receiveFun = receiveFun;
            serverSocket.Listen(10);    //设定最多10个排队连接请求


        }

        public bool Send(string value, bool bIsSyn = false)
        {
            Socket clientSocket = null;
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            if (_isSer)
            {
                clientSocket.Connect(new IPEndPoint(ip, myProt + 1));
            }
            else
            {
                clientSocket.Connect(new IPEndPoint(ip, myProt));
            }


            byte[] bs = Encoding.ASCII.GetBytes(value);//把字符串编码为字节  
            clientSocket.Send(bs, bs.Length, 0);//发送信息  

            // 接受服务器消息，验证是否接受
            if (bIsSyn)
            {
                string recvStr = "";
                byte[] recvBytes = new byte[1024];
                int bytes;
                bytes = clientSocket.Receive(recvBytes, recvBytes.Length, 0);//从服务器端接受返回信息  
                recvStr += Encoding.ASCII.GetString(recvBytes, 0, bytes);

                if (recvStr != "")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        // 这个函数是阻塞的
        public bool Receive(ref string value, bool bIsNeedRe = false)
        {
            Thread thread = new Thread(subReceive);
            thread.Start();

            return true;
        }


        private void subReceive()
        {
            bool bIsNeedRe = false;
            string recvStr = "";

            while (true)
            {
                try
                {
                    Socket socketOther = serverSocket.Accept();
                    byte[] recvBytes = new byte[1024];
                    int bytes;
                    bytes = socketOther.Receive(recvBytes, recvBytes.Length, 0);//从客户端接受信息
                    recvStr += Encoding.ASCII.GetString(recvBytes, 0, bytes);
                    _receiveFun(recvStr);
                    socketOther.Close();

                    if (bIsNeedRe)
                    {
                        string sendStr = "Ok";
                        byte[] bs = Encoding.ASCII.GetBytes(sendStr);
                        socketOther.Send(bs, bs.Length, 0);//返回信息给客户端
                        socketOther.Close();
                    }
                }
                catch (Exception e)
                {
                    return ;
                }
            }
        }

        public void Release()
        {
            serverSocket.Close();
            serverSocket.Dispose();
        }


        ~SocketImp()
        {
            serverSocket.Close();
            serverSocket.Dispose();
            
        }
    }
}
