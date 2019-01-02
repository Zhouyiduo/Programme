using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace IdentifyElementUI.IdentifyElementViewModel
{
    class IdentifyElementViewModel : NotificationObject
    {
        private string _progressTxt = string.Empty;

        public string ProgressTxt
        {
            get { return _progressTxt; }
            set
            {
                _progressTxt = value;
                this.RaisePropertyChanged("ProgressTxt");
            }
        }

        private string _percentageTxt = "0%";

        public string PercentageTxt
        {
            get { return _percentageTxt; }
            set
            {
                _percentageTxt = value;
                this.RaisePropertyChanged("PercentageTxt");
            }
        }

        private int _minBarValue = 0;

        public int MinBarValue
        {
            get { return _minBarValue; }
            set
            {
                _minBarValue = value;
                this.RaisePropertyChanged("MinBarValue");
            }
        }

        private int _maxBarValue = 1;

        public int MaxBarValue 
        {
            get { return _maxBarValue; }
            set
            {
                _maxBarValue = value;
                this.RaisePropertyChanged("MaxBarValue");
            }
        }

        private int _curBarValue = 0;

        public int CurBarValue
        {
            get { return _curBarValue; }
            set
            {
                _curBarValue = value;
                this.RaisePropertyChanged("CurBarValue");
            }
        }

        public DelegateCommand CloseBtnCommand { get; set; }

        private void CloseBtnCommandExecute()
        {
        }

        public IdentifyElementViewModel()
        {
            CloseBtnCommand = new DelegateCommand(new Action(CloseBtnCommandExecute));
        }
    }
}
