/*
* Course: 		Web Programming 3
* Assessment: 	Assignment 1
* Created by: 	Yorick-Ntwari Niyonkuru
* Date: 		12 September 2022
* Class Name: 	Letter.cs
* Description: 	Stores all data regarding letters.
    */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    public class Letter
    {
        public DateTime Date { get; set; }
        public string Recipient { get; set; }

        public Letter()
        {

        }

        public Letter(DateTime date_, string recipient_)
        {
            Date = date_;
            Recipient = recipient_;
        }

        public override string ToString()
        {
            return "Date: " + Date.ToString() + "\n" +
                "Recipient: " + Recipient;
        }

        public override bool Equals(object obj)
        {
            return obj is Letter letter &&
                   Date == letter.Date &&
                   Recipient == letter.Recipient;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Date, Recipient);
        }
    }
}
