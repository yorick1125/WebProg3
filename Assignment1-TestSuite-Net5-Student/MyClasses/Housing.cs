using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    class Housing
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

    }
}
