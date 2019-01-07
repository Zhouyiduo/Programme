using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExRef
{
    class Program
    {
        static void Main(string[] args)
        {
            CaObject obj= new CaObject(1,1,"S1");
            test1(obj);
            return;
        }


        static void test1(CaObject obj1)
        {
            List<CaObject> obj1New = new List<CaObject>();
            obj1New.Add(obj1);
            obj1New[0].M1 = 1000;
        }


        static void test2(CaObject obj2)
        {

        }


    }
}
