using ProcessCommunicationUtility;
using ProcessCommunicationUtility.MessageQueue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace IdentifyElementUI.IdentifyElementView
{
    /// <summary>
    /// IdentifyElementView.xaml 的交互逻辑
    /// </summary>
    public partial class IdentifyElementView : Window
    {
        public IdentifyElementView()
        {
            InitializeComponent();

            _identifyModelVM = new IdentifyElementViewModel.IdentifyElementViewModel();
            this.DataContext = _identifyModelVM;
            this.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            this.Topmost = true;
        }

        private IdentifyElementViewModel.IdentifyElementViewModel _identifyModelVM = null;
        private string _curProgressTxt = string.Empty;

        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);
            HwndSource source = PresentationSource.FromVisual(this) as HwndSource;
            source.AddHook(WndProc);
        }

        private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            switch (msg)
            {
                case ConstIdentifier.WM_COPYDATA:
                    string additionInfo = string.Empty;
                    MsgParam msgParam = MsgParam.eMin;
                    ProcessCommunicationUtility.MessageQueue.Operator.GetMsg(msg, wParam, lParam, ref msgParam, ref additionInfo);
                    CustomData data = CustomData.ParseString(additionInfo);
                    if (msgParam == MsgParam.eClose)
                    {
                        //关闭
                        complete(additionInfo);
                    }
                    else
                    {
                        //进度条相关消息
                        if (null != data)
                        {
                            _identifyModelVM.MinBarValue = data.MinVal;
                            _identifyModelVM.MaxBarValue = data.MaxVal;
                            _identifyModelVM.CurBarValue = 0;
                            _identifyModelVM.ProgressTxt = string.Format("{0}({1}/{2})", data.ProgressTxt, 0, data.MaxVal);
                            _identifyModelVM.PercentageTxt = "0%";
                            _curProgressTxt = data.ProgressTxt;
                        }
                        else
                        {
                            StepProgressBar();
                        }
                    }
                    break;
            }

            return IntPtr.Zero;
        }

        private void complete(string info)
        {
            this.Visibility = Visibility.Hidden;
            HintMsgView hintFrm = new HintMsgView(info);
            hintFrm.Show();
        }

        private void StepProgressBar()
        {
            if (_identifyModelVM.CurBarValue < _identifyModelVM.MaxBarValue)
            {
                ++_identifyModelVM.CurBarValue;
                _identifyModelVM.ProgressTxt = string.Format("{0}({1}/{2})", _curProgressTxt, _identifyModelVM.CurBarValue, _identifyModelVM.MaxBarValue);
                double percent = Convert.ToDouble(_identifyModelVM.CurBarValue) / Convert.ToDouble(_identifyModelVM.MaxBarValue);
                string result = percent.ToString("0%");
                _identifyModelVM.PercentageTxt = result;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void WrapPanel_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
        }
    }
}
