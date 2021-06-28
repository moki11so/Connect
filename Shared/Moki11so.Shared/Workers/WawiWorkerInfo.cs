using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Moki11so.Shared.Workers
{
    public class WawiWorkerInfo
    {
        public int EbayProcess { get; set; }
        public DateTime? EbayStartAt { get; set; }
        public DateTime? EbayEndeAt { get; set; }
        
        public int AmazonProcess { get; set; }
        public DateTime? AmazonStartAt { get; set; }
        public DateTime? AmazonEndeAt { get; set; }
        
        public int ShopProcess { get; set; }
        public DateTime? ShopStartAt { get; set; }
        public DateTime? ShopEndeAt { get; set; }

        public WawiWorkerOptions Options { get; set; }
    }
}
