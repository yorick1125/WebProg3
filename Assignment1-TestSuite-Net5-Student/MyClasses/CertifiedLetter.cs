using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    public class CertifiedLetter : Letter
    {
        public long TrackingNumber { get; set; }

        public CertifiedLetter(long trackingNumber_, DateTime date_, string recipient_) : base(date_, recipient_)
        {
            TrackingNumber = trackingNumber_;
        }

        public override string ToString()
        {
            return base.ToString() + "Tracking Number: " + TrackingNumber;
        }
    }
}
