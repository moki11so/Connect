using Moki11so.Shared.Essentials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moki11so.Shared.ShippingClasses
{
    public class ShippingClass
    {
        public int Wawi { get; set; }
        public decimal Price { get; set; }
        public int WawiVersand { get; set; }
        public decimal ShippingFree { get; set; }
        public Platform Platform { get; set; }
    }
}
