/*
* Course: Web Programming 3
* Assessment: 	Assignment 2
* Created by: 	Yorick-Ntwari Niyonkuru
* Date: 		25 September 2022
* Class Name: 	Course.cs
* Description: Explain what the class stores and its functionality. 
    */


using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment2
{
    public class Course
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Semester { get; set; }
        public int Duration { get; set; }
    }
}
