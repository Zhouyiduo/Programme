using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchableTextBox.Models
{
    public class SearchModel
    {
        #region Fields

        private string _id = string.Empty;
        private string _name = string.Empty;
        private string _searchField = string.Empty;
        private object _tag = null;

        #endregion

        #region Properties

        public string Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public string SearchField { get => _searchField; set => _searchField = value; }
        public object Tag { get => _tag; set => _tag = value; }

        #endregion
    }
}
