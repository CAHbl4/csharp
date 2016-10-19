using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    class Student
    {
        public string Surname { get; set; }
        decimal stipend, stipendInDollars;
        public Student(string surname="",decimal stip=0)
        {
            Surname = surname;
            stipend = stip;
            stipendInDollars = stipend /(decimal) 1.95;
        }
        public override string ToString()
        {
            return " Я - "+Surname+",  моя стипендия - "+stipendInDollars+" $";
        }
        public void OnChangeInBank(object ob)
        {
            Bank bank = ob as Bank;
            if (bank != null)
                stipendInDollars = stipend / bank.DollarRate;
        }
    }
}
