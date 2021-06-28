namespace Moki11so.Shared.Drives
{
    public class Drive
    {
        public bool Fixed { get; set; }
        public bool InUse { get; set; }
        public string Name { get; set; }
        public long TotalSize { get; set; }
        public long AvailableFreeSpace { get; set; }
    }
}