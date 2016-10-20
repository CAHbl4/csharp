using System;

namespace Home6
{
    public class Patient
    {
        DateTime _admissionDate;
        int _age;
        Diagnoz _diagnoz;

        public Patient()
        {
        }

        public Patient(string name, int age, DateTime admissionDate, Diagnoz diagnoz)
        {
            Name = name;
            Age = age;
            AdmissionDate = admissionDate;
            Diagnoz = diagnoz;
        }

        public Diagnoz Diagnoz
        {
            get { return _diagnoz; }
            set
            {
                if (value == null) return;
                if (_diagnoz != null)
                {
                    _diagnoz.DepartmentChanged -= OnDiagnozDepartmentChanged;
                    _diagnoz.DurationChanged -= OnDiagnozDurationChanged;
                }
                _diagnoz = value;
                _diagnoz.DepartmentChanged += OnDiagnozDepartmentChanged;
                _diagnoz.DurationChanged += OnDiagnozDurationChanged;

                DataVipiski = AdmissionDate.AddDays(Diagnoz.Duration);
                Department = Diagnoz.Department;
            }
        }

        public string Department { get; set; }

        public int Age
        {
            get { return _age; }
            set
            {
                if (value < 1) throw new ArgumentOutOfRangeException("Age should be greater than 0");
                _age = value;
            }
        }

        public DateTime AdmissionDate
        {
            get { return _admissionDate; }
            set
            {
                if (value > DateTime.Today)
                    throw new ArgumentOutOfRangeException("Admission date cant be in future");
                _admissionDate = value;
            }
        }

        public DateTime DataVipiski { get; set; }

        public string Name { get; set; }

        public void OnDiagnozDepartmentChanged(object sender, EventArgs e)
        {
            if (_diagnoz == null) return;
            if (sender == _diagnoz)
                Department = _diagnoz.Department;
        }

        public void OnDiagnozDurationChanged(object sender, EventArgs e)
        {
            if (_diagnoz == null) return;
            if (sender == _diagnoz)
                DataVipiski = AdmissionDate.AddDays(_diagnoz.Duration);
        }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, " +
                   $"{nameof(Age)}: {Age}, " +
                   $"{nameof(Diagnoz)}: {Diagnoz.Name}, " +
                   $"{nameof(Department)}: {Department}, " +
                   $"{nameof(AdmissionDate)}: {AdmissionDate:d}, " +
                   $"{nameof(DataVipiski)}: {DataVipiski:d}, ";
        }
    }
}