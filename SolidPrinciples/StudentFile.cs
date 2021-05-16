using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace SolidPrinciples
{
    public class StudentFile
    {
        private string file;
        public StudentFile(string filename)
        {
            if (file != "")
            {
                file = filename;
            }
            else
            {
                File.CreateText(file);
            }
        }

        public void AddingToFile(String line)
        {
            using (StreamWriter stream = File.AppendText(file))
            {
                stream.WriteLine(line);
            }
        }

        public List<Student> ReadText()
        {
            List<Student> students = new();

            string[] lines = File.ReadAllLines(file);

            if (lines.Length > 0)
            {
                foreach (var line in lines)
                {
                    string[] split = line.Split(',');

                    if (split[0].Equals("Fulltime"))
                    {
                        string studentId = split[1];
                        string firstName = split[2];
                        string lastName = split[3];
                        string campus = split[4];

                        FStudent fulltime = new(studentId, firstName, lastName, true,campus);
                        students.Add(fulltime);
                    }
                    else
                    {
                        string studentId = split[1];
                        string firstName = split[2];
                        string lastName = split[3];
                        string lecturer = split[4];

                        DStudent dts = new (studentId, lecturer, firstName, lastName, true);
                        students.Add(dts);
                    }
                }
            }
            return students;
        }
    }
}
