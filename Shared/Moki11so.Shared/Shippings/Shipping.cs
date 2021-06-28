using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moki11so.Shared.Shippings
{
    public class Shipping
    {
        public string ExternalOrderNumber { get; set; }
        public string OrderNumber { get; set; }
        public string OrderReference { get; set; }
        public int WawiOrder { get; set; }
        public DateTime ShippedAt { get; set; }
        public string TrackingCode { get; set; }
        public int Carrier { get; set; }

    }
}
