using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment2
{
    public class Student
    {
        public string First { get; set; }
        public string Last { get; set; }
        public int Age { get; set; }
        public int ID { get; set; }
        public List<int> Scores;

        public override string ToString()
        {
            return String.Format("{0} {1}", First, Last);
        }
    }
}
