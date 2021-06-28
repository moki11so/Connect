using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moki11so.Shared.Essentials;

namespace Moki11so.Shared.Orders
{
    public class Order
    {
        public int WawiOrder { get; set; }
        public string OrderNumber { get; set; }
        public string OrderReference { get; set; }
        public bool Internal { get; set; }
        public Platform Platform { get; set; }
        public OrderShipper Shipper { get; set; }
        public OrderReceiver Receiver { get; set; }
        public IEnumerable<OrderPosition> Positions { get; set; }
    }
}
