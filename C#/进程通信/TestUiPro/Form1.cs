using ProIOPro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using UiPro;

namespace TestUiPro
{
    public partial class Form1 : Form
    {

        public ClientPro _clientPro = null;
        ProIO _proIo = null;

        

        public Form1()
        {
            InitializeComponent();

            MessageOpert mOpert = new MessageOpert(this.Handle);
            _proIo = new ProIO(TypeWayProIP.Socket, false, mOpert.receive); // 
            
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            //ProcessStartInfo startInfo = new ProcessStartInfo();
            //startInfo.FileName = "D:\\Deom20181204\\Deom\\UiPro\\UiPro\\bin\\Debug\\UiPro.exe";
            //System.Diagnostics.Process.Start(startInfo);
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
           
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            ClientPro.SendMessage();
        }

        public void Log(string sLog)
        {
            
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
           
        }

        private void btnSocket_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(500);
                _proIo.Send("test");
            }

            //IPAddress ip = IPAddress.Parse("127.0.0.1");
            //Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //serverSocket.Bind(new IPEndPoint(ip, 8889));  //绑定IP地址：端口

            //serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //serverSocket.Bind(new IPEndPoint(ip, 8889));  //绑定IP地址：端口


            return;
        }

        private void btnControl_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(1000);
            }
        }

        protected override void DefWndProc(ref System.Windows.Forms.Message m)
        {
            const int msgUser = MessageOpert.USER;


            switch (m.Msg)
            {
                case msgUser:
                    MessageBox.Show("收到消息");
                    break;
                default:
                    base.DefWndProc(ref m);//一定要调用基类函数，以便系统处理其它消息。
                    break;
            }
        }
    }
}
