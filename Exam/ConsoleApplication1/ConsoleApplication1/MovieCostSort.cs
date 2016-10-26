using System.Collections.Generic;
using BL;

namespace ConsoleApplication1
{
    public class MovieCostSort : IComparer<AbstractMovie>
    {
        public int Compare(AbstractMovie x, AbstractMovie y)
        {
            return x.GetCost().CompareTo(y.GetCost());
        }
    }
}