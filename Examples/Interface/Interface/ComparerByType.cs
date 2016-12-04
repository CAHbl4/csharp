using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    class ComparerByType:IComparer
    {
        public int Compare(object x, object y)
        {

            if (x.GetType() == y.GetType())
                return 0;
            if (x.GetType() == typeof(Circle))
                return -1;
            return 1;
        }
    }
}
