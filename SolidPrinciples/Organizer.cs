using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples
{
    public class Organizer
    {
        public static string StudentReport(List<Student> students)
        {
            int fullTimeStudentsCount = 0;
            int distanceStudentsCount = 0;
            string fulltime = "";
            string partTime = "";

            foreach (Student item in students)
            {
                if (item is FStudent student)
                {
                    fullTimeStudentsCount++;
                    fulltime += $"{student.StudentId}\t{student.FirstName}\t{student.Campus}\n";
                }
                else if (item is DStudent distanceStudent)
                {
                    distanceStudentsCount++;
                    partTime += $"{distanceStudent.StudentId}\t{distanceStudent.FirstName}\t{distanceStudent.Lecturer}\n";
                }
            }
            if (fullTimeStudentsCount == 0 && distanceStudentsCount == 0)
            {
                return $"There are currently no students in our system";
            }
            else if (fullTimeStudentsCount == 0 && distanceStudentsCount > 0)
            {
                return $"There are currently no Fulltime students and there are {distanceStudentsCount} distance students captured in our system\n\nPART TIME STUDENTS:\n{partTime}";
            }
            else if (fullTimeStudentsCount > 0 && distanceStudentsCount == 0)
            {
                return $"There are currently {fullTimeStudentsCount} Fulltime Students and no distance students have been captured \n\nFULL TIME STUDENTS:\n{fulltime}";
            }
            else
            {
                return $"There are {fullTimeStudentsCount} Full Time Students\nThere are {distanceStudentsCount} Part Time Students\n\nFULL TIME STUDENTS:\n{fulltime}\n\nPART TIME STUDENTS:\n{partTime}";
            }
        }

        public static string Format(Student student)
        {
            if (student is FStudent)
            {
                FStudent fulltime = (FStudent)student;
                return $"Fulltime,{fulltime.StudentId},{fulltime.FirstName},{fulltime.LastName},{fulltime.Campus}";
            }
            else if (student is DStudent distance)
            {
                return $"Distance,{distance.StudentId},{distance.FirstName}#{distance.LastName},{distance.Lecturer}";
            }
            else
            {
                return $"Exception,{student.StudentId}";
            }
        }
    }
}
