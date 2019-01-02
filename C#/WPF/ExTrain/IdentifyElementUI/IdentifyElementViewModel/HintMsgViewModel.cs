using Microsoft.Practices.Prism.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentifyElementUI.IdentifyElementViewModel
{
    class HintMsgViewModel : NotificationObject
    {
        private string _resultTxt;

        public string ResultTxt
        {
            get { return _resultTxt; }
            set
            {
                _resultTxt = value;
                this.RaisePropertyChanged("ResultTxt");
            }
        }

        public HintMsgViewModel(string info)
        {
            ResultTxt = string.Format("共识别{0}个图元", info);
        }
    }
}
