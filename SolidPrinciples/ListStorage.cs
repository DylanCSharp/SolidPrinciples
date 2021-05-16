using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples
{
    public class ListStorage
    {
        private static List<Student> students = new();

        public static List<Student> GetStudents()
        {
            return students;
        }

        public static void SetStudents(List<Student> studentList)
        {
            students = studentList;
        }

        public static void AddStudent(Student studentAdd)
        {
            students.Add(studentAdd);
        }
    }
}
