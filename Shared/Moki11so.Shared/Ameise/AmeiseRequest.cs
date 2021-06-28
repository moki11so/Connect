using Moki11so.Shared.Essentials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moki11so.Shared.Ameise
{

    public class AmeiseRequest : AmeiseSync
    {
        public int WawiExport { get; set; }
        public Platform Platform { get; set; }
        public int SyncType { get; set; }
    }
}
