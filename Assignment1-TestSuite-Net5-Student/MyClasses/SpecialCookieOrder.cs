using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    public class SpecialCookieOrder : CookieOrder
    {
        public const decimal HANDLINGFEE = 5m;
        public string Description { get; set; }
        public SpecialCookieOrder(string customerName_, uint orderNumber_, uint quantity_, string cookieType_, string description_) : base(customerName_, orderNumber_, quantity_, cookieType_)
        {
            Description = description_;
        }

        public override string ToString()
        {
            return base.ToString() + "Description: " + Description + "\n";
        }

        public override bool Equals(object obj)
        {
            SpecialCookieOrder order = (SpecialCookieOrder)obj;
            return base.Equals(obj) && order.Description == Description;
        }

        public override decimal CalculatePrice()
        {
            return base.CalculatePrice() + HANDLINGFEE;

        }
    }
}
