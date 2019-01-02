using IdentifyElementUI.IdentifyElementViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace IdentifyElementUI.IdentifyElementView
{
    /// <summary>
    /// HintMsgView.xaml 的交互逻辑
    /// </summary>
    public partial class HintMsgView : Window
    {
        public HintMsgView(string info)
        {
            InitializeComponent();

            this.DataContext = new HintMsgViewModel(info);
            this.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        private void WrapPanel_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            System.Environment.Exit(0);
        }
    }
}
