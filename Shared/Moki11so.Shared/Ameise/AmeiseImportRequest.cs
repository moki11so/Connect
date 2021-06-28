using Moki11so.Shared.Essentials;

namespace Moki11so.Shared.Ameise
{
    public class AmeiseImportRequest : AmeiseSync
    {
        public int WawiImport { get; set; }
        public Platform Platform { get; set; }
        public int SyncType { get; set; }
        public string LocalPath { get; set; }
        public string RemotePath { get; set; }
    }
}
