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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ExRelativeSource
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            RelativeSource rs = new RelativeSource(RelativeSourceMode.FindAncestor);
            //设定为离自己控件最近的第二层父控件
            rs.AncestorLevel = 2;
            //设定父控件为Gird类型
            rs.AncestorType = typeof(Grid);
            //绑定源为Grid的名称
            Binding binding = new Binding("Name") { RelativeSource = rs };
            //将绑定的源放在文本显示内容中
            this.textBox1.SetBinding(TextBox.TextProperty, binding);

        }
    }
}
