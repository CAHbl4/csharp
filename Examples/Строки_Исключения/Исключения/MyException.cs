using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Исключения
{
    class MyException:ApplicationException
    {
        public DateTime TimeOfError { get; set; }
        public MyException(string mes,DateTime dt):base(mes)
        {
            TimeOfError = dt;
        }

    }
}
