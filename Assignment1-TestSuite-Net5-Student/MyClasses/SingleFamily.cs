using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    public class SingleFamily : IUnits
    {
        public string Address { get; set; }
        public int Beds { get; set; }
        public int Baths { get; set; }
        public decimal RentAmount { get; set; }
        public int Size { get; set; }
        public int NumberGarages { get; set; }
        public int NumberBedrooms { get; set; }

        public SingleFamily()
        {

        }

        public SingleFamily(string addr_)
        {
            Address = addr_;
        }
        public SingleFamily(string addr_, int beds_, int baths_, decimal rent_)
        {
            Address = addr_;
            Beds = beds_;
            Baths = baths_;
            RentAmount = rent_;
        }

        public decimal ProjectedRentalAmt()
        {
            throw new NotImplementedException();
        }
    }
}
