using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment2
{
    public static class Queries
    {
        /// <summary>
        ///  This method gets all students who are under the specified age ordered by their age
        /// </summary>
        /// <param name="students"></param>
        /// <param name="age"></param>
        /// <returns> IEnumerable<Student> </returns>
        public static IEnumerable<Student> StudentsUnderSpecificAge(
            this IEnumerable<Student> students, int age)
        {
            return students.Where(student => student.Age < age).OrderBy(student => student.Age);
        }

        /// <summary>
        ///  This method gets all students who are between the ages of 13 and 19 inclusively
        /// </summary>
        /// <param name="students"></param>
        /// <returns> IEnumerable<Student> </returns>
        public static IEnumerable<Student> StudentTeenagers(
    this IEnumerable<Student> students)
        {
            return students.Where(student => student.Age < 20 && student.Age > 12).OrderBy(student => student.Last);
        }

        /// <summary>
        /// This method gets all the students who scored 80 or more in their last test (order by score descending)
        /// </summary>
        /// <param name="students"></param>
        /// <param name="score"></param>
        /// <returns> IEnumerable<Student> </returns>
        public static IEnumerable<Student> StudentsScoringOverNumberInLastTest(
this IEnumerable<Student> students, int score)
        {
            return students.Where(student => student.Scores[student.Scores.Count() - 1] > score).OrderByDescending(student => student.Scores[student.Scores.Count() - 1]);
        }

        /// <summary>
        /// This method gets all students who scored over 320 marks in total (across all their tests)
        /// </summary>
        /// <param name="students"></param>
        /// <param name="score"></param>
        /// <returns> IEnumerable<Student> </returns>
        public static IEnumerable<Student> StudentsScoringOverNumberInTotal(
this IEnumerable<Student> students, int score)
        {
            return students.Where(student => student.Scores.Sum() > score);
        }

        /// <summary>
        /// This methos gets all students who scored at least 60 in all their tests
        /// </summary>
        /// <param name="students"></param>
        /// <param name="score"></param>
        /// <returns> IEnumerable<Student> </returns>
        public static IEnumerable<Student> StudentsScoringAtLeastNumberInAll(
this IEnumerable<Student> students, int score)
        {
            return students.Where(student => student.Scores.Min() >= score);
        }

        /// <summary>
        /// This method returns all students grouped by the first letter of their last name
        /// </summary>
        /// <param name="students"></param>
        /// <returns> IEnumerable<Student> </returns>
        public static IEnumerable<IGrouping<char, Student>> StudentsGroupedByLastName(
this IEnumerable<Student> students)
        {
            return students.OrderBy(student => student.Last).GroupBy(student => student.Last[0]);
        }

        /// <summary>
        /// This method gets the average score of all students for each test 
        /// </summary>
        /// <param name="students"></param>
        /// <returns> IEnumerable<double> </returns>
        public static IEnumerable<double> AveragePerTest(
this IEnumerable<Student> students)
        {

            List<List<int>> allScores = students.Select(student => student.Scores).ToList();
            int numberOfTests = allScores.First().Count();

            List<double> avgScores = allScores.SelectMany(score => score)
                               .Select((value, index) => new { Value = value, Index = index % numberOfTests }) // if we have four tests and a list of students, thisfirst test will be allscores[0], second will be allscores [4], etc....
                               .GroupBy(score => score.Index)
                               .Select(testScores => testScores.Average(score => score.Value)).ToList();

            return avgScores;
        }

        /// <summary>
        /// This method gets all the students who are also teachers
        /// </summary>
        /// <param name="students"></param>
        /// <param name="staff"></param>
        /// <returns> IEnumerable<Student> </returns>
        public static IEnumerable<Student> StudentTeachers(
this IEnumerable<Student> students, IEnumerable<Staff> staff)
        {
            return students.Where(student =>
            (from staffMember in staff select staffMember.First).Contains(student.First) &&
            (from staffMember in staff select staffMember.Last).Contains(student.Last));
        }

        /// <summary>
        /// This method gets all the courses whose duration is the duration passed as a parameter
        /// </summary>
        /// <param name="courses"></param>
        /// <param name="duration"></param>
        /// <returns> IEnumerable<Course> </returns>
        public static IEnumerable<Course> GetCoursesByDuration(
this IEnumerable<Course> courses, int duration)
        {
            return courses.Where(course => course.Duration == duration).ToList();
        }

        /// <summary>
        /// This method gets all the courses whose semester is the semester passed as a parameter
        /// </summary>
        /// <param name="courses"></param>
        /// <param name="semester"></param>
        /// <returns> IEnumerable<Course> </returns>
        public static IEnumerable<Course> GetCoursesBySemester(
this IEnumerable<Course> courses, string semester)
        {
            return courses.Where(course => course.Semester == semester).OrderBy(course => course.Duration).ToList();
        }

        /// <summary>
        /// This method gets all the courses grouped by semester
        /// </summary>
        /// <param name="courses"></param>
        /// <returns> IEnumerable<Course> </returns>
        public static IEnumerable<IGrouping<string, Course>> GroupCoursesBySemester(
this IEnumerable<Course> courses)
        {
            return courses.GroupBy(course => course.Semester);
        }



    }

}

