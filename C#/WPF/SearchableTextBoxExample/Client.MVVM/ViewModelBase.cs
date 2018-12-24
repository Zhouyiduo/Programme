using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Windows;
using System.Collections.ObjectModel;

namespace Client.MVVM
{
    [Serializable]
    public class ViewModelBase :INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged<T>(Expression<Func<T>> propertyExpresssion)
        {
            string propertyName = ExtractPropertyName(propertyExpresssion);
            this.RaisePropertyChanged(propertyName);
        }

        protected void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this,new PropertyChangedEventArgs(propertyName));
            }
        }        

        public static string ExtractPropertyName<T>(Expression<Func<T>> propertyExpresssion)
        {
            var memberExpression = propertyExpresssion.Body as MemberExpression;
            return memberExpression.Member.Name;
        }
    }  
}
