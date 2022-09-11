using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    public class SingleFamily : Housing, IUnits
    {
        public const int MONTHSINAYEAR = 12;
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

        public SingleFamily(string addr_, int beds_, int baths_, decimal rent_)
        {
            Address = addr_;
            Beds = beds_;
            Baths = baths_;
            RentAmount = rent_;
        }

        public SingleFamily(string addr_, int beds_, int baths_, decimal rent_, int size_, int numGarages_, int numBedrooms_)
        {
            Address = addr_;
            Beds = beds_;
            Baths = baths_;
            RentAmount = rent_;
            Size = size_;
            NumberGarages = numGarages_;
            NumberBedrooms = numBedrooms_;
        }

        public decimal ProjectedRentalAmt()
        {
            return RentAmount * MONTHSINAYEAR;
        }



        public override string ToString()
        {
            return "Address: " + Address + "\n" +
                "Rooms: " + Beds + " Beds & " + Baths + "Baths" + "\n" +
                "Monthly Rent: " + RentAmount.ToString("C");
        }


        public override bool Equals(object obj)
        {
            return obj is SingleFamily family &&
                   Address == family.Address &&
                   Beds == family.Beds &&
                   Baths == family.Baths &&
                   RentAmount == family.RentAmount &&
                   Size == family.Size &&
                   NumberGarages == family.NumberGarages &&
                   NumberBedrooms == family.NumberBedrooms;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Address, Beds, Baths, RentAmount, Size, NumberGarages, NumberBedrooms);
        }
    }
}
