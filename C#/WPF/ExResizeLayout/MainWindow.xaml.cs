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

namespace ExResizeLayout
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //Test();
        }

        public void Test()
        {
            //RelativeSource rs = new RelativeSource(RelativeSourceMode.FindAncestor);
            ////设定为离s自己控件最近的第一层父控件  
            //rs.AncestorLevel = 1;
            ////设定父控件为Gird类型
            //rs.AncestorType = typeof(Grid);
            ////绑定源为Grid的名称  
            //Binding binding = new Binding("Name") { RelativeSource = rs };
            ////将绑定的源放在文本显示内容中  
            //this.textBox1.SetBinding(TextBox.TextProperty, binding);  
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void StackPanel_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void WindowName_Loaded_1(object sender, RoutedEventArgs e)
        {
            dataGrid1.Items.Add(new FillData("1","name1","context1"));
            dataGrid1.Items.Add(new FillData("2", "name2", "context2"));
            dataGrid1.Items.Add(new FillData("3", "name3", "context3"));

            //List<FillData> datas = new List<FillData>();
            //datas.Add();
        }

        private void WindowName_Drop_1(object sender, DragEventArgs e)
        {
            return;
        }

        private void WindowName_SizeChanged_1(object sender, SizeChangedEventArgs e)
        {
            return;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            FillData fillData = null;
            testc(fillData);
            return;
        }

        private void testc(FillData fillDataPar)
        {
            //fillDataPar.Index = "2";
            fillDataPar = new FillData("3", "Name", "Context"); 
        }
    }
}
