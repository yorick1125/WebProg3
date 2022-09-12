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

        public SingleFamily(int year_, string addr_, string constructionType_, string cleaningCrew_, bool insuranceClaimHistory_, int beds_, int baths_, decimal rent_, int size_, int numGarages_, int numBedrooms_) : base(year_, addr_, constructionType_, cleaningCrew_, insuranceClaimHistory_)
        {
            Address = addr_;
            Beds = beds_;
            Baths = baths_;
            RentAmount = rent_;
            Size = size_;
            NumberGarages = numGarages_;
            NumberBedrooms = numBedrooms_;
        }


        public SingleFamily(int year_) : base(year_)
        {
        }



        public decimal ProjectedRentalAmt()
        {
            return RentAmount * MONTHSINAYEAR;
        }



        public override string ToString()
        {
            return base.ToString() + "\n" +
                "Rooms: " + Beds + " Beds & " + Baths + " Baths" + "\n" +
                "Monthly Rent: " + RentAmount.ToString("C");
        }




        public override int GetHashCode()
        {
            return HashCode.Combine(Address, Beds, Baths, RentAmount, Size, NumberGarages, NumberBedrooms);
        }

        public override bool Equals(object obj)
        {
            return obj is SingleFamily family &&
                   base.Equals(obj) &&
                   Address == family.Address &&
                   Beds == family.Beds &&
                   Baths == family.Baths &&
                   RentAmount == family.RentAmount &&
                   Size == family.Size &&
                   NumberGarages == family.NumberGarages &&
                   NumberBedrooms == family.NumberBedrooms;
        }
    }
}
