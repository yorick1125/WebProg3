using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    public class MultiUnits : Housing, IUnits
    {
        public const int MONTHSINAYEAR = 12;

        public int NoOfUnits { get; set; }
        public decimal RentAmountPerUnit { get; set; }
        public MultiUnits()
        {

        }
        public MultiUnits(string addr_)
        {
            Address = addr_;
        }
        public MultiUnits(string addr_, int numberUnits_, decimal rentAmt_)
        {
            Address = addr_;
            NoOfUnits = numberUnits_;
            RentAmountPerUnit = rentAmt_;
        }

        public MultiUnits(int year_) : base(year_)
        {
        }

       public MultiUnits(int year_, string addr_, string constructionType_, string cleaningCrew_, bool insuranceClaimHistory_, int numberUnits_, decimal rentAmt_) : base(year_, addr_, constructionType_, cleaningCrew_, insuranceClaimHistory_)
        {
            NoOfUnits = numberUnits_;
            RentAmountPerUnit = rentAmt_;
        }

        public decimal ProjectedRentalAmt()
        {
            return RentAmountPerUnit * NoOfUnits * MONTHSINAYEAR;
        }



        public override int GetHashCode()
        {
            return HashCode.Combine(Address, NoOfUnits, RentAmountPerUnit);
        }

        public override string ToString()
        {
            return base.ToString() + "\n" +
                    "Number of Units: " + NoOfUnits + "\n" +
                    "Monthly Rent Per Unit: " + RentAmountPerUnit + "\n";
        }

        public override bool Equals(object obj)
        {
            return obj is MultiUnits units &&
                   base.Equals(obj) &&
                   NoOfUnits == units.NoOfUnits &&
                   RentAmountPerUnit == units.RentAmountPerUnit;
        }
    }
}
