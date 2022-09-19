using System;
using System.Collections.Generic;
using static System.Console;

namespace Assignment2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = Util.GenerateStudents();

            int minScore = 80;
            WriteLine(String.Format("These students scored over {0} in the last test. ", minScore));
            foreach(Student student in students.StudentsScoringOverNumberInLastTest(minScore))
            {
                WriteLine(student.ToString() + " scored " + student.Scores[student.Scores.Count - 1]);
            }
        }
    }
}
