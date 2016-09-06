using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events_and_delegates
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Faculty> faculties = new List<Faculty>();
            faculties.Add(new Faculty("A1", "Ivanov", "11-22-33"));

            List<Student> students = new List<Student>();
            students.Add(new Student("Sidorov","A1",33,5,6,4,3));
            students.Add(new Student("Petrov","A1",43,1,3,0,1));

            foreach (var student in students)
            {
                faculties.First(x => x.Name == student.Faculty).NameChanged += student.OnFacultyNameChanged;
            }

            foreach (var student in students)
            {

                Console.WriteLine(student);
            }

            faculties[0].Name = "B1";

            foreach (var student in students)
            {
                Console.WriteLine(student);
            }
            
            Console.ReadKey();
        }
    }
}
