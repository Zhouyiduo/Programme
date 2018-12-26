using LoadInventoryUI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeViewStyle
{
    public class TVData : NotificationObject
    {

        public static void CreateData(ref List<TVData> lstData)
        {
            for (int i = 0; i < 3; i++ )
            {
                TVData data = new TVData(i,"m" + i.ToString());
                data.ParentId = 0;
                for (int j = 0; j < 4; j++)
                {
                    TVData datasub = new TVData(i, "j" + i.ToString());
                    data.ParentId = i;
                    data.ChildNodes.Add(datasub);
                }
                lstData.Add(data);
            }
            return;
        }

        public TVData(int id,string name)
        {
            Id = id;
            Name = name;
            ChildNodes = new List<TVData>(); 
        }

        // 这里必须是属性，不能用成员变量
        public int Id  { get; set; }
        public string Name { get; set; }
        public int ParentId { get; set; }
        public List<TVData> ChildNodes { get; set; }
    }
}
