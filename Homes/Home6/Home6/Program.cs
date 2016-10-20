using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home6
{
    class Program
    {
        static void Main(string[] args)
        {
            Diagnoz angina = new Diagnoz("Angina","Terapia",5);
            Diagnoz perelom = new Diagnoz("Perelom","Hirurgia",20);
            Diagnoz gripp = new Diagnoz("Gripp", "Terapia",7);

            List<Patient> patients = new List<Patient>
            {
                new Patient("Ivanov", 20, DateTime.Parse("10-10-2016"), angina),
                new Patient("Petrov", 23, DateTime.Parse("11-10-2016"), perelom),
                new Patient("Sidorov", 25, DateTime.Parse("12-10-2016"), gripp),
                new Patient("Pushkin", 22, DateTime.Parse("13-10-2016"), angina),
            };

            foreach (Patient patient in patients)
            {
                Console.WriteLine(patient);
            }

            Console.WriteLine();

            angina.Duration = 10;
            foreach (Patient patient in patients)
            {
                Console.WriteLine(patient);
            }

            Console.WriteLine();

            perelom.Department = "Terapia";

            foreach (Patient patient in patients)
            {
                Console.WriteLine(patient);
            }

            Console.ReadKey();
            }
    }
}
