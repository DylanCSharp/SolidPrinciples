using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples
{
    public class DStudent : Student
    {
        public DStudent(string studentId,string lecturer, string firstName, string lastName, bool enrolled) : base(studentId, firstName, lastName, enrolled)
        {
            Lecturer = lecturer;
        }

        public string Lecturer { get; set; }
    }
}
