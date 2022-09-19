using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment2
{
    public static class Queries
    {
        public static IEnumerable<Student> StudentsUnderSpecificAge(
            this IEnumerable<Student> students, int age)
        {
            return students.Where(student => student.Age < age);
        }

        public static IEnumerable<Student> StudentTeenagers(
    this IEnumerable<Student> students, int age)
        {
            return students.Where(student => student.Age < age).OrderBy(student => student.Age);
        }

        public static IEnumerable<Student> StudentsScoringOverNumberInLastTest(
this IEnumerable<Student> students, int score)
        {
            return students.Where(student => student.Scores[student.Scores.Count() - 1] > score);
        }

        public static IEnumerable<Student> StudentsScoringOverNumberInTotal(
this IEnumerable<Student> students, int score)
        {
            return students.Where(student => student.Scores.Sum() > score);
        }

        public static IEnumerable<Student> StudentsScoringAtLeastNumberInAll(
this IEnumerable<Student> students, int score)
        {
            return students.Where(student => student.Scores.Min() > score);
        }

        public static IEnumerable<double> AveragePerTest(
this IEnumerable<Student> students, int score)
        {
            List<double> avgScores = new List<double>();
            for(int i = 0; i < 4; i++)
            {
                int sum = 0;
                int studentCount = 0;
                // sum up all scores per test
                foreach(Student student in students)
                {
                    sum += student.Scores[i];
                    studentCount++;
                }
                avgScores.Add(sum / studentCount);
            }

            return avgScores;
        }

        public static IEnumerable<Student> StudentTeachers(
this IEnumerable<Student> students, IEnumerable<Staff> staff)
        {
            return students.Where(student =>
            (from staffMember in staff select staffMember.First).Contains(student.First) &&
            (from staffMember in staff select staffMember.Last).Contains(student.Last));
        }


        public static IEnumerable<Course> GetCoursesByDuration(
this IEnumerable<Course> courses, int duration)
        {
            return courses.Where(course => course.Duration == duration).ToList();
        }

        public static IEnumerable<Course> GetCoursesBySemester(
this IEnumerable<Course> courses, string semester)
        {
            return courses.Where(course => course.Semester == semester).OrderBy(course => course.Duration).ToList();
        }

        public static IEnumerable<Course> GroupCoursesBySemester(
this IEnumerable<Course> courses)
        {
            return (IEnumerable<Course>)courses.GroupBy(course => course.Semester);
        }



    }

}

