using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using static System.Console;
using System.IO;

namespace Assignment2
{
    class SchoolViewModel
    {
        private StringBuilder builder;
        public string filePath { get { return "../../../../"; } }
        public List<Student> Students { get { return Util.GetStudents(); } }
        public List<Staff> Staffs { get { return Util.GetStaff(); } }
        public List<Course> Courses { get { return Util.GetCourses(); } }
        public enum Selection
        {
            Under18,
            Teenagers,
            Over80Final,
            Over320Total,
            Min60,
            GroupByName,
            AverageForEach,
            StudentTeachers,
            Courses15Weeks,
            CoursesInWinter,
            CoursesGroupedBySemester,
            All,
            Exit


        }

  

        public Selection currentSelection;
        public SchoolViewModel()
        {
        }

        public void WelcomeMessage()
        {
            WriteLine("Welcome to the school repository interface! ");
        }

        public void PromptUserSelection()
        {
            WriteLine("Please choose which option you would like to run: ");
            PrintAllSelections();
            currentSelection = (Selection)(Util.GetIntInput(ReadLine(), 0, 12));
        }

        public void PrintAllSelections()
        {
            builder = new StringBuilder();

            builder.AppendLine("[0] Students who are under 18 years of age (in order of age)");
            builder.AppendLine("[1] Students who are teenagers (alphabetical order by last name)");
            builder.AppendLine("[2] Students who scored 80 or more in their last test (order by score descending)");
            builder.AppendLine("[3] Students who scored over 320 marks in total (across all their tests)");
            builder.AppendLine("[4] Students who scored at least 60 in all their tests");
            builder.AppendLine("[5] Students grouped by first letter of their last name");
            builder.AppendLine("[6] Average score of each test");
            builder.AppendLine("[7] Students who are also teachers");
            builder.AppendLine("[8] Courses of a duration of 15 weeks");
            builder.AppendLine("[9] Courses held in the Winter semester (order by duration)");
            builder.AppendLine("[10] Courses grouped by semester");
            builder.AppendLine("[11] All of the above");
            builder.AppendLine("[12] Exit");

            WriteLine(builder.ToString());
        }


        public void RunCurrentSelection()
        {
            builder = new StringBuilder();
            switch (currentSelection)
            {
                case Selection.Under18:
                    Under18Format();
                    break;
                case Selection.Teenagers:
                    TeenagersFormat();
                    break;
                case Selection.Over80Final:
                    Over80FinalFormat();
                    break;
                case Selection.Over320Total:
                    Over320TotalFormat();
                    break;
                case Selection.Min60:
                    Min60Format();
                    break;
                case Selection.GroupByName:
                    GroupByNameFormat();
                    break;
                case Selection.AverageForEach:
                    AverageForEachFormat();
                    break;
                case Selection.StudentTeachers:
                    StudentTeachersFormat();
                    break;
                case Selection.Courses15Weeks:
                    Courses15WeeksFormat();
                    break;
                case Selection.CoursesInWinter:
                    CoursesInWinterFormat();
                    break;
                case Selection.CoursesGroupedBySemester:
                    CoursesGroupedBySemesterFormat();
                    break;
                case Selection.All:
                    Under18Format();
                    TeenagersFormat();
                    Over80FinalFormat();
                    Over320TotalFormat();
                    Min60Format();
                    GroupByNameFormat();
                    AverageForEachFormat();
                    StudentTeachersFormat();
                    Courses15WeeksFormat();
                    CoursesInWinterFormat();
                    CoursesGroupedBySemesterFormat();
                    break;
                case Selection.Exit:
                    WriteLine("Thank you for using this program have a nice day!");
                    Environment.Exit(1);
                    break;

            }


            // Write Output to Console
            WriteLine(builder.ToString());
            WriteLine("Would you like to save the output to a txt file? Type Y or N ");
            string result;
            do
            {
                result = ReadLine();
                if (result.ToLower() == "y")
                {
                    try
                    {
                        // Write Output to File
                        Util.WriteToFile(builder, filePath);
                        WriteLine("Successfully wrote output to Solution-Output.txt");
                    }
                    catch (Exception e)
                    {
                        WriteLine(e.Message);
                    }
                }
                else if (result.ToLower() == "n")
                {
                    WriteLine("Press any key to return to main menu ...");
                }
                else
                {
                    WriteLine("Please enter a valid input");
                }
            } while (result.ToLower() != "y" && result.ToLower() != "n");

            ReadKey();
        }

        public void Under18Format()
        {
            builder.AppendLine("Students who are under 18 years of age:");
            foreach (Student student in Students.StudentsUnderSpecificAge(18))
            {
                builder.AppendLine(String.Format("- {0} ({1})", student.ToString(), student.Age));
            }
            builder.AppendLine("");
        }
        public void TeenagersFormat()
        {
            builder.AppendLine("Students who are teenagers:");
            foreach (Student student in Students.StudentTeenagers())
            {
                builder.AppendLine(String.Format("- {0} ({1})", student.ToString(), student.Age));
            }
            builder.AppendLine("");
        }
        public void Over80FinalFormat()
        {
            builder.AppendLine("Students who scored 80 or more in their last test:");
            foreach (Student student in Students.StudentsScoringOverNumberInLastTest(80))
            {
                builder.AppendLine(String.Format("- {0} ({1})", student.ToString(), student.Scores[student.Scores.Count - 1]));
            }
            builder.AppendLine("");
        }
        public void Over320TotalFormat()
        {
            builder.AppendLine("Students who scored over 320 marks in total:");
            foreach (Student student in Students.StudentsScoringOverNumberInTotal(320))
            {
                builder.AppendLine(String.Format("- {0} ({1} total marks)", student.ToString(), student.Scores.Sum()));
            }
            builder.AppendLine("");
        }
        public void Min60Format()
        {
            builder.AppendLine("Students who scored at least 60 in all their tests:");
            foreach (Student student in Students.StudentsScoringAtLeastNumberInAll(60))
            {
                builder.AppendLine(String.Format("- {0} ({1})", student.ToString(), student.ScoresStringFormat()));
            }
            builder.AppendLine("");
        }
        public void GroupByNameFormat()
        {
            builder.AppendLine("Students grouped by first letter of last name:");
            foreach (var letter in Students.StudentsGroupedByLastName())
            {
                builder.AppendLine(letter.Key.ToString());
                foreach (var student in letter)
                {
                    builder.AppendLine("   " + student.ToString());
                }
            }
            builder.AppendLine("");
        }
        public void AverageForEachFormat()
        {
            List<double> averages = Students.AveragePerTest().ToList();
            for (int i = 0; i < averages.Count; i++)
            {
                builder.AppendLine("Average score of test " + (i + 1).ToString() + ": " + Math.Round(averages[i], 2));
            }
            builder.AppendLine("");
        }
        public void StudentTeachersFormat()
        {
            builder.AppendLine("Students who are also teachers:");
            foreach (Student student in Students.StudentTeachers(Staffs))
            {
                builder.AppendLine(student.ToString());
            }
            builder.AppendLine("");
        }
        public void Courses15WeeksFormat()
        {
            builder.AppendLine("Courses of a duration of 15 weeks:");
            foreach (Course course in Courses.GetCoursesByDuration(15))
            {
                builder.AppendLine("* " + course.Name);
            }
            builder.AppendLine("");
        }
        public void CoursesInWinterFormat()
        {
            builder.AppendLine("Courses held in the Winter semester:");
            foreach (Course course in Courses.GetCoursesBySemester("Winter"))
            {
                builder.AppendLine("* " + course.Name);
            }
            builder.AppendLine("");
        }
        public void CoursesGroupedBySemesterFormat()
        {
            builder.AppendLine("Courses grouped by semester:");
            foreach (var group in Courses.GroupCoursesBySemester())
            {
                builder.AppendLine(group.Key.ToString());
                foreach (var course in group)
                {
                    builder.AppendLine("   " + course.Name);
                }
            }
            builder.AppendLine("");
        }


    }
}
