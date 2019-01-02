using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ProcessCommunicationUtility.MessageQueue
{
    public class Operator
    {
        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        private static extern int SendMessage(
        int hWnd, // handle to destination window
        int Msg, // message
        int wParam, // first message parameter
        ref COPYDATASTRUCT lParam // second message parameter
        );

        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        private static extern int FindWindow(string lpClassName, string lpWindowName);

        public static int SendMsg(string frmTitle, MsgParam wParam, string lParam)
        {
            int WINDOW_HANDLER = FindWindow(null, frmTitle);
            if (WINDOW_HANDLER != 0)
            {
                byte[] sarr = System.Text.Encoding.Default.GetBytes(lParam);
                int len = sarr.Length;
                COPYDATASTRUCT cds;
                cds.dwData = (IntPtr)100;
                cds.lpData = lParam;
                cds.cbData = len + 1;

                SendMessage(WINDOW_HANDLER, ConstIdentifier.WM_COPYDATA, (int)wParam, ref cds);
            }
            return WINDOW_HANDLER;
        }

        public static bool GetMsg(int msg, IntPtr wParam, IntPtr lParam, ref MsgParam msgParm, ref string customVal)
        {
            if (msg == ConstIdentifier.WM_COPYDATA)
            {
                int msgType = (int)wParam;
                msgParm = (MsgParam)msgType;
                COPYDATASTRUCT cds = (COPYDATASTRUCT)Marshal.PtrToStructure(lParam, typeof(COPYDATASTRUCT));
                customVal = cds.lpData;
                return true;
            }
            return false;
        }
    }
}
