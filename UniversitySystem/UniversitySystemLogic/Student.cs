using System;
using System.Collections.Generic;
using System.Linq;

namespace UniversitySystemLogic
{
    public class Student
    {
        public string studentName;
        private Dictionary<string, List<int>> marks;
        

        public Student(string studentName)
        {
            this.studentName = studentName;
            marks = new Dictionary<string, List<int>>();
        }

        public void AddMark(string subjectTitle, List<int> mark) => marks.Add(subjectTitle, mark);

        public double GetEverage()
        {
            return marks.Average(mark => GetEverage(mark.Key));
        }

        public double GetEverage(string subject)
        {
            if (subject == null) throw new ArgumentNullException(nameof(subject));

            return marks[subject].Average();
        }

    }
}
