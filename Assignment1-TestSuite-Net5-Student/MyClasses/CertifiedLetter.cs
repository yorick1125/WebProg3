/*
* Course: 		Web Programming 3
* Assessment: 	Assignment 1
* Created by: 	Yorick-Ntwari Niyonkuru
* Date: 		10 September 2022
* Class Name: 	CertifiedLetter.cs
* Description: 	Stores all data regarding certified letters.
    */ 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    public class CertifiedLetter : Letter 
    {
        public long TrackingNumber { get; set; }

        public CertifiedLetter(long trackingNumber_, DateTime date_, string recipient_) : base(date_, recipient_)
        {
            TrackingNumber = trackingNumber_;
        }

        public override string ToString()
        {
            return base.ToString() + "\n" + 
                "Tracking Number: " + TrackingNumber;
        }

        public override bool Equals(object obj)
        {
            return obj is CertifiedLetter letter &&
                   base.Equals(obj) &&
                   TrackingNumber == letter.TrackingNumber;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), Date, Recipient, TrackingNumber);
        }
    }
}
