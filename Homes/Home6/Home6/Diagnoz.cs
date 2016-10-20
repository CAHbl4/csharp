using System;
using System.Runtime.InteropServices;

namespace Home6
{
    public class Diagnoz
    {
        int _duration;
        string _department;

        public event EventHandler<EventArgs> DepartmentChanged;
        public event EventHandler<EventArgs> DurationChanged;
        public string Name { get; set; }

        public string Department
        {
            get { return _department; }
            set
            {
                _department = value;
                DepartmentChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public Diagnoz()
        {
        }

        public Diagnoz(string name, string deparment, int duration)
        {
            _duration = duration;
            Name = name;
            Department = deparment;
        }

        public int Duration
        {
            get { return _duration; }
            set
            {
                if (value< 0) throw new ArgumentOutOfRangeException("Duration should be greater than 0");
                _duration = value;
                DurationChanged?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}