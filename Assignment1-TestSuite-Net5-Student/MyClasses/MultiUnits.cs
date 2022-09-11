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

        public string Address { get; set; }
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

        public decimal ProjectedRentalAmt()
        {
            return RentAmountPerUnit * NoOfUnits * MONTHSINAYEAR;
        }

        public override bool Equals(object obj)
        {
            return obj is MultiUnits units &&
                   Address == units.Address &&
                   NoOfUnits == units.NoOfUnits &&
                   RentAmountPerUnit == units.RentAmountPerUnit;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Address, NoOfUnits, RentAmountPerUnit);
        }

        public override string ToString()
        {
            return "Address: " + Address + "\n" +
                    "Number of Units: " + NoOfUnits + "\n" +
                    "Monthly Rent Per Unit: " + RentAmountPerUnit + "\n";
        }
    }
}
