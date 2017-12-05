using System;
using System.Collections.Generic;
using System.Linq;

namespace UniversitySystemLogic 
{
    public class Group
    {
        public string groupNumber;
        public List<Student> Students { get; set; }

        public Group(string groupNumber)
        {
            this.groupNumber = groupNumber;
            Students = new List<Student>();
        }

        public void AddStudent(Student studentName) => Students.Add(studentName);

        public double GetEverage()
        {
            return Students.Average(student => student.GetEverage());
        }

        public double GetEverage(string subject)
        {
            if (subject == null) throw new ArgumentNullException(nameof(subject));

            return Students.Average(student => student.GetEverage(subject));
        }
    }
}
