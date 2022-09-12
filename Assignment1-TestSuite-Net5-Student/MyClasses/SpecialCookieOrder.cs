/*
* Course: 		Web Programming 3
* Assessment: 	Assignment 1
* Created by: 	Yorick-Ntwari Niyonkuru
* Date: 		12 September 2022
* Class Name: 	SpecialCookieOrder.cs
* Description: 	Stores all data regarding special .
    */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    public class SpecialCookieOrder : CookieOrder
    {
        public static decimal HANDLINGFEE = 5m;
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

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), CustomerName, OrderNumber, Quantity, CookieType, TotalPrice, Description);
        }
    }
}
