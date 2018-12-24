
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfBing
{
    public class ViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public void Notify(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }

        }
        private string name = "测试数据";

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                Notify("Name");
            }
        }
        void UpdateArtistNameExecute()
        {
            this.Name = "中孝介";
        }

        bool CanUpdateArtistNameExecute()
        {
            return true;
        }
        public ICommand UpdateData { get { return new RelayCommand(UpdateArtistNameExecute, CanUpdateArtistNameExecute); } }
        public ICommand NameChanged { get { return new RelayCommand(NameChang); } }

        private void NameChang()
        {
            string na = Name;
        }
    }
}