using LoadInventoryUI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeViewStyle
{
    public class ViewMode : NotificationObject
    {
        private List<TVData> _tData = new List<TVData>();
        public List<TVData> TData
        {
            get
            {
                return _tData;
            }

            set
            {
                _tData = value;
                this.RaisePropertyChanged("TData");
            }

        }

        public ViewMode()
        {
            TVData.CreateData(ref _tData);
        }
    }
}
