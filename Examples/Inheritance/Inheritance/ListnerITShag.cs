using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    class ListnerITShag:Human
    {
        public string group;
        public ListnerITShag(string fam = "",  int year = 0, string group = "")
            : base(fam, "слушатель АйТиШаг", year)
        {
            this.group = group;
        }

        public override double SrBall()
        {
            return DateTime.Now.Year - year;
        }
    }
}
