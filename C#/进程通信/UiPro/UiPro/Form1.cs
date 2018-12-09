using ProIOPro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UiPro
{
    public partial class FormEx : Form
    {
       
        int parVale = 0;

        ProIO _proIo = null;

        public FormEx()
        {
            InitializeComponent();
            progressBarTest.Minimum = 0;
            progressBarTest.Maximum = 100;
            progressBarTest.Value = 0;//设置当前值

            MessageOpert mOpert = new MessageOpert(this.Handle);
            _proIo = new ProIO(TypeWayProIP.Socket, true, mOpert.receive); 

        }

        
       

        private void BtnTest_Click(object sender, EventArgs e)
        {
            if (parVale < 100)
            {
                parVale += 10;
            }

            progressBarTest.Value = parVale;

        }

        public void SetProValue(int value)
        {
            progressBarTest.Value = value;
        }

        private void FormEx_Shown(object sender, EventArgs e)
        {
        }

        private void FormEx_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void btnListen_Click(object sender, EventArgs e)
        {
            
        }

        private void FormEx_Load(object sender, EventArgs e)
        {
            
        }

        public void AddPro()
        {
            if (parVale < 100)
            {
                parVale += 10;
            }

            progressBarTest.Value = parVale;

          
        }

        protected override void DefWndProc(ref System.Windows.Forms.Message m)
        {
            const int msgUser = MessageOpert.USER;


            switch (m.Msg)
            {
                case msgUser:
                    AddPro();
                    break;
                default:
                    base.DefWndProc(ref m);//一定要调用基类函数，以便系统处理其它消息。
                    break;
            }
        }

        private void btnSocket_Click(object sender, EventArgs e)
        {
            _proIo.Send("server message!");

        }
    }
}
