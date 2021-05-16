using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples
{
    public abstract class Student
    {
        public Student(string studentId, string firstName, string lastName, bool enrolled)
        {
            StudentId = studentId;
            FirstName = firstName;
            LastName = lastName;
            Enrolled = enrolled;
        }

        public string StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Enrolled { get; set; }
    }
}
