/*
* Course: 		Web Programming 3
* Assessment: 	Assignment 1
* Created by: 	Yorick-Ntwari Niyonkuru
* Date: 		10 September 2022
* Class Name: 	Housing.cs
* Description: 	Base class for all housing classes such as SingleFamily or MultiUnits.
    */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    public class Housing
    {

        public int Year { get; set; }
        public string Address { get; set; }
        public string ConstructionType { get; set; }
        public string CleaningCrew { get; set; }
        public bool InsuranceClaimHistory { get; set; }
        public Housing()
        {

        }
        public Housing(int year_)
        {
            Year = year_;
        }

        public Housing(int year_, string addr_, string constructionType_, string cleaningCrew_, bool insuranceClaimHistory_)
        {
            Year = year_;
            Address = addr_;
            ConstructionType = constructionType_;
            CleaningCrew = cleaningCrew_;
            InsuranceClaimHistory = insuranceClaimHistory_;
        }

        public override bool Equals(object obj)
        {
            return obj is Housing housing &&
                   Year == housing.Year &&
                   ConstructionType == housing.ConstructionType &&
                   CleaningCrew == housing.CleaningCrew &&
                   InsuranceClaimHistory == housing.InsuranceClaimHistory;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Year, Address, ConstructionType, CleaningCrew, InsuranceClaimHistory);
        }

        public override string ToString()
        {
            return
                "Year: " + Year + " \n" +
                "Address: " + Address + " \n" +
                "Construction Type: " + ConstructionType + " \n" +
                "Cleaning Crew: " + CleaningCrew + " \n" +
                "Insurance Claim History: " + InsuranceClaimHistory + " \n";
        }

    }
}
