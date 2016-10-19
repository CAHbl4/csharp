using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attributes
{
    [Displayed,Status(ObjectStatus.Looser,IsSecret=true)]
    class Document
    {
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Shifr { get; set; }
        public override string ToString()
        {
            return Title + " " + Price + " " + Shifr;
        }

    }
}
