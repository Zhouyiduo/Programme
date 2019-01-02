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

namespace PublicControlLibrary.CostomControl
{
    /// <summary>
    /// SearchTextBox.xaml 的交互逻辑
    /// </summary>
    public partial class SearchTextBox : UserControl
    {
        public delegate void SearchFunDeal();

        public SearchTextBox()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 输入的搜索条件字符串
        /// </summary>
        public static readonly DependencyProperty SearchTextProperty
            = DependencyProperty.Register("SearchText", typeof(string), typeof(SearchTextBox), new PropertyMetadata(null, null));



         public static readonly RoutedEvent clickEvent =
             EventManager.RegisterRoutedEvent("SearchFun", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(SearchTextBox));


        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            //PART_TextBoxInput.Text = SearchText;

            if (PART_TextBoxInput != null)
            {
                //SearchText = PART_TextBoxInput.Text;
                PART_TextBoxInput.TextChanged += _ttbInput_TextChanged;
                PART_TextBoxInput.AcceptsReturn = false;
            }

            PART_ButtonSearch.Click += _btnClick;
        }

        private void _ttbInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            if ( !string.IsNullOrEmpty(PART_TextBoxInput.Text) )//输入为空，显示Tips，隐藏清除按钮
            {
                SearchText = PART_TextBoxInput.Text;
            }
        }

        private void SearchableTextBox_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            SearchText = PART_TextBoxInput.Text;
            return;
        }
        // 搜索的内容
        public string SearchText
        {
            get
            {
                return (string)GetValue(SearchTextProperty);
            }
            set
            {
               SetValue(SearchTextProperty,value);
            }
        }

        // 搜索的需要调用的函数
        public event RoutedEventHandler SearchFun
        {
            add
            {
                AddHandler(clickEvent,value);
            }

            remove
            {
                RemoveHandler(clickEvent, value);
            }
        }

        private void _btnClick(object sender, RoutedEventArgs e)
        {
            // 调用搜索功能
            RoutedEventArgs args = new RoutedEventArgs(clickEvent, this);
            RaiseEvent(args);
        }


        //private static void OnSearchTextPropretyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        //{
        //    SearchTextBox stb = d as SearchTextBox;
        //    if ( stb == null )
        //    {
                
        //        return;
        //    }
        //}

    }
}
