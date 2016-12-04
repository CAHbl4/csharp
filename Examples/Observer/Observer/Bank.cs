using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    class Bank
    {
        decimal dollarRate;
        //ChangeInBank observer;
        public event  ChangeInBank observer;
        public string Name { get; set; }
        public Bank(string name="",decimal rate=0,params ChangeInBank[] obs)
        {
            Name = name;
            
            foreach (ChangeInBank ob in obs)
                observer += ob;
            DollarRate = rate;
         }
        //public void ObserverRegistrate(ChangeInBank ob)
        //{
        //    observer += ob;
        //}
        public decimal DollarRate
        {
            get
            {
                return dollarRate;
            }
            set
            {
                dollarRate=value;
                if (observer != null) observer(this);
            }
        }
    }
}
