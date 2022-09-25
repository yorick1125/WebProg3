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
            return String.Format("{0}, {1}", Last, First);
        }

        public string ScoresStringFormat()
        {
            string s = "";

            if(Scores.Count < 1)
            {
                return "Scores List is empty";
            }
            foreach(int score in Scores)
            {
                s += score.ToString();
                if (score != Scores[Scores.Count - 1]){
                    s += " ";
                }
            }
            return s;
        }
    }
}
