using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace SearchableTextBox.Helpers
{
    public class LVTreeHelper
    {
        public static T GetAncestor<T>(DependencyObject source) where T : DependencyObject
        {
            if (source == null)
                return null;
            do
            {
                source = VisualTreeHelper.GetParent(source);
            } while (source != null && !(source is T));

            return source as T;
        }
    }
}
