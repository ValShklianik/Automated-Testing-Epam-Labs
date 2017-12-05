using System;
using System.Collections.Generic;
using System.Linq;

namespace UniversitySystemLogic
{
    public class Faculty
    {
        public string facultyName;
        public List<Group> Groups { get; set; }

        public Faculty(string facultyName)
        {
            this.facultyName = facultyName;
            Groups = new List<Group>();
        }

        public void AddGroups(Group groupNumber) => Groups.Add(groupNumber);

        public double GetEverage()
        {
            return Groups.Average(group => group.GetEverage());
        }

        public double GetEverage(string subject)
        {
            if (subject == null) throw new ArgumentNullException(nameof(subject));

            return Groups.Average(group => group.GetEverage(subject));
        }

    }
}
