namespace MoSo.Connect.Service
{
	public interface IReportingService
	{
		void SendInitialWorkerInfos();
		void SendInitialWawiWorkerInfos();
		void SendMetaInfos();
		void SendDriveInfos();
		void SendFinishWorker();
	}
}