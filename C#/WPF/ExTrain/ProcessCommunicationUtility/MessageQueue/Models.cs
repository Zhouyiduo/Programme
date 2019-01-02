using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ProcessCommunicationUtility.MessageQueue
{
    public class ConstIdentifier
    {
        //定义消息常数
        public const int WM_COPYDATA = 0x004A;

        public const string IdentifyElementFrmTitle = "IdentifyElementView";

        public const string ExtractFloor = "正在提取楼层...";

        public const string ExtractCalcInfo = "正在提取计算信息...";

        public const string ExtractHandrail = "正在提取栏杆扶手...";
        public const string ExtractApron = "正在提取散水...";
        public const string ExtractFootStep = "正在提取台阶...";
        public const string ExtractParapet = "正在提取栏板...";
        public const string ExtractCanopy = "正在提取雨蓬...";
        public const string ExtractCoping = "正在提取压顶...";
        public const string ExtractRamp = "正在提取坡道...";

        public const string ExtractColumn = "正在提取柱...";
        public const string ExtractTieColumn = "正在提取构造柱...";
        public const string ExtractMasonryColumn = "正在提取砌体柱...";

        public const string ExtractCustomPoint = "正在提取自定义点...";
        public const string ExtractCustomLine = "正在提取自定义线...";
        public const string ExtractCustomFace = "正在提取自定义面...";

        public const string ExtractHungCeiling = "正在提取吊顶...";
        public const string ExtractFloorFinish = "正在提取楼地面...";
        public const string ExtractCeiling = "正在提取天棚...";

        public const string ExtractIsolatedFD = "正在提取独立基础...";
        public const string ExtractStripFD = "正在提取条形基础...";
        public const string ExtractPile = "正在提取桩...";
        public const string ExtractColumnBase = "正在提取柱墩...";

        public const string ExtractRibbonWin = "正在提取带形窗...";
        public const string ExtractSwingWin = "正在提取飘窗...";
        public const string ExtractDormer = "正在提取老虎窗...";
        public const string ExtractColumnCap = "正在提取柱帽...";
    }

    public class CustomData
    {
        public int MinVal { get; set; }
        public int MaxVal { get; set; }
        public string ProgressTxt { get; set; }

        public CustomData(int curMinVal, int curMaxVal, string curProgressTxt)
        {
            MinVal = curMinVal;
            MaxVal = curMaxVal;
            ProgressTxt = curProgressTxt;
        }

        public override string ToString()
        {
            string str = string.Format("{0},{1},{2}", MinVal, MaxVal, ProgressTxt);
            return str;
        }

        public static CustomData ParseString(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return null;
            }
            string[] items = str.Split(',');
            if (items.Count() != 3)
            {
                return null;
            }
            int val1 = -1;
            int.TryParse(items[0], out val1);

            int val2 = -1;
            int.TryParse(items[1], out val2);

            CustomData data = new CustomData(val1, val2, items[2]);
            return data;
        }
    }

    public struct COPYDATASTRUCT
    {
        public IntPtr dwData; //可以是任意值
        public int cbData;    //指定lpData内存区域的字节数
        [MarshalAs(UnmanagedType.LPStr)]
        public string lpData; //发送给目录窗口所在进程的数据
    }

    public enum MsgParam
    {
        //置顶,传递给wParam
        eTopMost = 0,
        //最小化,传递给wParam
        eMin,
        //自定义属性,传递给wParam,自定义数据传递给lParam
        eClose,
        eCustom = 10000
    }
}
