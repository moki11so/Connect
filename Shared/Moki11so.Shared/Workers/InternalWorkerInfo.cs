using System;

namespace Moki11so.Shared.Workers
{
    public class InternalWorkerInfo
    {
        public DateTime? LastFinishAt { get; set; }
        public float? Version { get; set; }
        public DateTime? LastConnectAt { get; set; }
        public string WawiVersion { get; set; }
        public string ServerName { get; set; }
        public string OperatingSystem { get; set; }
        public string SqlUsedSpace { get; set; }
        
        public string SqlServerName { get; set; }
        public string SqlInstanceName { get; set; }
        public string SqlEdition { get; set; }
        public string SqlVersion { get; set; }
        public string SqlVersionName { get; set; }

        public string SqlDb { get; set; }
        public string SqlConnections { get; set; }
    }
}