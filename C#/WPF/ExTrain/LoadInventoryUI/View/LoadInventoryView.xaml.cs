//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows;
//using System.Windows.Controls;
//using System.Windows.Data;
//using System.Windows.Documents;
//using System.Windows.Input;
//using System.Windows.Media;
//using System.Windows.Media.Imaging;
//using System.Windows.Navigation;
//using System.Windows.Shapes;

using LoadInventoryUI.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LoadInventoryUI.View
{


    
    /// <summary>
    /// LoadInventoryModelView.xaml 的交互逻辑
    /// </summary>
    public partial class LoadInventoryView : Window
    {

        public LoadInventoryView()
        {
            InitializeComponent();
            LoadInventoryViewModel.VM = new LoadInventoryViewModel();
            this.DataContext = LoadInventoryViewModel.VM;
            
        }

        public void SetData(List<ProjectsLib> projectLibs)
        {
            LoadInventoryViewModel.VM.SetData(projectLibs);
        }

        private void WrapPanel_MouseLeftButtonDown_Load(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }


        private void Button_Click_Close(object sender, RoutedEventArgs e)
        {
            // 初始化BQRUleManager

            this.Close();
        }

        // 添加搜索功能
        private void Button_Click_Search(object sender, RoutedEventArgs e)
        {
            LoadInventoryViewModel vm = (LoadInventoryViewModel)this.DataContext;
            
            if( vm == null)
                return;

            string sSearchText = vm.SearchContext;
            // 调用搜索接口，给列表控件赋值

            List<BQRuleVM> lstBqRuleSea = vm.SelectedProjectsLib.SearchBqRulesByCode(sSearchText);

            // 编码为空
            if (lstBqRuleSea.Count == 0)
            {
                // 按项目名称搜索
                lstBqRuleSea = vm.SelectedProjectsLib.SearchBqRulesByProject(sSearchText);
            }

            vm.BQRuleVMList = lstBqRuleSea;

            return;

        }


        private void OnLoad(object sender, EventArgs e)
        {
            return;
        }

        // 确定按钮事件
        private void Button_Click_Sure(object sender, EventArgs e)
        {
            return;
        }

        // 取消按钮事件
        private void Button_Click_Cancel(object sender, EventArgs e)
        {
            return;
        }


        //private void SetTXDataGrid()
        //{
        //    for (int i = 0; i < this.GridRule.Items.Count; i++)
        //    {
        //        DataRowView drv = GridRule.Items[i] as DataRowView;
        //        DataGridRow row = (DataGridRow)this.GridRule.ItemContainerGenerator.ContainerFromIndex(i);
        //        {
        //            DataGridCellsPresenter presenter = GetVisualChild<DataGridCellsPresenter>(row);
        //            DataGridCell cell = (DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(1);
        //            cell.Background = new SolidColorBrush(Colors.Red);
        //        }
        //    }
        //}

        //public static T GetVisualChild<T>(Visual parent) where T : Visual
        //{
        //    T childContent = default(T);
        //    int numVisuals = VisualTreeHelper.GetChildrenCount(parent);
        //    for (int i = 0; i < numVisuals; i++)
        //    {
        //        Visual v = (Visual)VisualTreeHelper.GetChild(parent, i);
        //        childContent = v as T;
        //        if (childContent == null)
        //        {
        //            childContent = GetVisualChild<T>(v);
        //        }
        //        if (childContent != null)
        //        {
        //            break;
        //        }
        //    }

        //    return childContent;
        //}

    }
}
