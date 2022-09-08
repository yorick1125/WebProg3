using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    public class MultiUnits : IUnits
    {
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
            throw new NotImplementedException();
        }
    }
}
