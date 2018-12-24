using SearchableTextBoxExample.ViewModel;
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

namespace SearchableTextBoxExample.View
{
    /// <summary>
    /// SearchableTextBoxExample.xaml 的交互逻辑
    /// </summary>
    public partial class SearchableTextBoxExample : UserControl
    {
        #region Fields

        private SearchableTextBoxExampleViewModel _viewModel = null;

        #endregion

        #region Constructors

        public SearchableTextBoxExample()
        {
            InitializeComponent();

            _viewModel = new SearchableTextBoxExampleViewModel();
            DataContext = _viewModel;
        }

        #endregion

        #region Event Methods

        private void stbTest_SelectedSearchItemChanged(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(stbTest.SelectedSearchItem.Name);
        }

        #endregion
    }
}
