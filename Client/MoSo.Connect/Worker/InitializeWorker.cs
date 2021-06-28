using Microsoft.Extensions.Logging;
using MoSo.Connect.Service;

namespace MoSo.Connect.Worker
{
	public class InitializeWorker : IWorkerService
	{
		private readonly ILogger<InitializeWorker> _logger;
		private readonly IReportingService _reportingService;
		private readonly IPlatformService _platformService;

		public static readonly string WorkerName = $"{nameof(IWorkerService)}.Initialize";

		public InitializeWorker(ILogger<InitializeWorker> logger,
			IReportingService reportingService,
			IPlatformService platformService)
		{
			_logger = logger;
			_reportingService = reportingService;
			_platformService = platformService;
		}

		public void Run()
		{
			_reportingService.SendInitialWorkerInfos();
			_reportingService.SendInitialWawiWorkerInfos();
			_reportingService.SendMetaInfos();
			_platformService.EnsureWawiPlatformExists();
		}
	}
}