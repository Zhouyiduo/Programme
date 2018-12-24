using Client.MVVM;
using SearchableTextBox.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchableTextBoxExample.ViewModel
{
    public class SearchableTextBoxExampleViewModel : ViewModelBase
    {
        #region Fields

        #endregion

        #region Properties

        public ObservableCollection<SearchModel> SearchItemsSourceCollection { get; set; }

        #endregion

        #region Constructors

        public SearchableTextBoxExampleViewModel()
        {
            SearchItemsSourceCollection = new ObservableCollection<SearchModel>();
            for (int i = 0; i < 10000; i++)
            {
                SearchModel sm = new SearchModel();
                sm.Name = "测试数据" + i;
                sm.Id = Guid.NewGuid().ToString();
                sm.SearchField = "搜索测试" + i + "附加数据" + i;
                SearchItemsSourceCollection.Add(sm);
            }
        }

        #endregion

    }
}
