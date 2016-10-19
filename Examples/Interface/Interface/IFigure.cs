using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    interface IFigure:IComparable
    {
        double Square
        { get; }

        void ShowInfo();
    }
}
