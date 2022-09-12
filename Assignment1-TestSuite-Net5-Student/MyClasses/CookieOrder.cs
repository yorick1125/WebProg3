/*
* Course: 		Web Programming 3
* Assessment: 	Assignment 1
* Created by: 	Yorick-Ntwari Niyonkuru
* Date: 		12 September 2022
* Class Name: 	Letter.cs
* Description: 	Stores all data regarding letters.
    */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    public class CookieOrder
    {
        public static decimal WHOLESALEPRICE = 1.5m;
        public static decimal REGULARPRICE = 2.25m;
        public static int MIN_QUANTITY_FOR_WHOLESALEPRICE = 24;

        public string CustomerName { get; set; }
        public uint OrderNumber { get; set; }
        public uint Quantity { get; set; }
        public string CookieType { get; set; }
        public decimal TotalPrice { get { return CalculatePrice(); } }
        public CookieOrder(string customerName_, uint orderNumber_, uint quantity_, string cookieType_)
        {
            CustomerName = customerName_;
            OrderNumber = orderNumber_;
            Quantity = quantity_;
            CookieType = cookieType_;
        }

        public virtual decimal CalculatePrice()
        {
            if(Quantity < MIN_QUANTITY_FOR_WHOLESALEPRICE)
            {
                return Quantity * REGULARPRICE;
            }
            else
            {
                return Quantity * WHOLESALEPRICE;
            }
        }

        public override string ToString()
        {
            return 
                "Customer Name: " + CustomerName + "\n" +
                "Order Number: " + OrderNumber + "\n" +
                "Quantity: " + Quantity + "\n" +
                "CookieType: " + CookieType + "\n" +
                "Total Price: " + TotalPrice.ToString("C") + "\n"
                ;
        }

        public override bool Equals(object obj)
        {
            CookieOrder order = (CookieOrder)obj;
            return order.CustomerName == CustomerName &&
                order.OrderNumber == OrderNumber &&
                order.Quantity == Quantity &&
                order.CookieType == CookieType;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(CustomerName, OrderNumber, Quantity, CookieType, TotalPrice);
        }
    }
}
