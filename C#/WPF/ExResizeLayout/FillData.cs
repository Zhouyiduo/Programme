using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExResizeLayout
{
    public class FillData
    {
        public FillData(string index, string name,string context)
        {
            Index = index;
            Name = name;
            Context = context;
        }

        public string Index{get;set;}
        public string Name { get; set; }
        public string Context { get; set; }
    }
}
