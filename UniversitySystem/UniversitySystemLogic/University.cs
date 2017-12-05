using System;
using System.Collections.Generic;
using System.Linq;

namespace UniversitySystemLogic
{
    public class Universiry
    {
        private string universiryName;
        public List<Faculty> Faculty { get; set; }

        public Universiry(string universiryName)
        {
            this.universiryName = universiryName;
            Faculty = new List<Faculty>();
        }

        public void AddFaculty(Faculty fName) => Faculty.Add(fName);

        public double GetEverage()
        {
            return Faculty.Average(f => f.GetEverage());
        }

        public double GetEverage(string subject)
        {
            if (subject == null) throw new ArgumentNullException(nameof(subject));

            return Faculty.Average(f => f.GetEverage(subject));
        }

    }
}
