using System.Linq;

namespace Events_and_delegates
{
    public class Student
    {
        private string lastName;
        private string faculty;
        private double stipend;
        private int[] marks;

        public Student()
        {
        }

        public Student(string lastName, string faculty, double stipend, params int[] marks)
        {
            this.lastName = lastName;
            this.faculty = faculty;
            this.stipend = stipend;
            this.marks = marks;
        }


        public double AverageMark
        {
            get { return marks.Average(); }
        }

        public string Faculty
        {
            get { return faculty; }
        }

        public bool IsLoser
        {
            get { return AverageMark < 2; }

        }

        public void OnFacultyNameChanged(string newFacultyName)
        {
            faculty = newFacultyName;
        }

        public override string ToString()
        {
            return string.Format("LastName: {0}, Faculty: {1}, Stipend: {2}, AverageMark: {3}", lastName, faculty, stipend, AverageMark);
        }
    }
}