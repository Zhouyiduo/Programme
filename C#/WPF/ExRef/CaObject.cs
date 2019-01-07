using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExRef
{

    public class CaSubObject
    {
        public int m1;
        public int m2;
        public string m3;
    }

    public class CaObject
    {
        public CaObject(int m1,int m2,string m3)
        {
            M1 = m1;
            M2 = m2;
            M3 = m3;
        }
        public CaObject(){}

        public int M1;
        public int M2;
        public string M3;
    }
}
