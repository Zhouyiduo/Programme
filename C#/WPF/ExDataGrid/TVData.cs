
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExDataGrid
{
    public class TVData : NotificationObject
    {

        public static void CreateData(ref List<TVData> lstData)
        {
            for (int i = 0; i < 3; i++ )
            {
                TVData data = new TVData(i, "Name" + i.ToString() + "Name" + i.ToString() + "Name" + i.ToString() + "Name" + i.ToString() + "Name" + i.ToString(),
                    "Context" + i.ToString() + "\n" + "Context" + i.ToString() + "\n" + "Context" + i.ToString() + "\n" + "Context" + i.ToString());
                lstData.Add(data);
            }
            return;
        }

        public TVData(int id,string name,string context)
        {
            Id = id;
            Name = name;
            Context = context;
        }

        // 这里必须是属性，不能用成员变量
        public int Id  { get; set; }
        public string Name { get; set; }
        public string Context { get; set; }

       
    }
}
