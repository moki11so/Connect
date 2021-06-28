using Moki11so.Shared.Essentials;

namespace Moki11so.Shared.Ameise
{
    public class AmeiseQueue : AmeiseSync
    {
        public string LocalPath { get; set; }
        public Platform Platform { get; set; }
        public string LicenseHash { get; set; }
        public int SyncType { get; set; }
        public int Process { get; set; }
    }
}
