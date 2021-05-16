using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples
{
    public class FStudent : Student
    {
        public string Campus { get; set; }

        public FStudent(string studentId, string firstName, string lastName, bool enrolled, string campus) : base(studentId, firstName, lastName, enrolled)
        {
            Campus = campus;
        }
    }
}
