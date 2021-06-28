using System;
using LightInject;
using Microsoft.Extensions.Logging;
using Moki11so.Shared.Essentials;
using MoSo.Connect.Service;

namespace MoSo.Connect.Worker
{
	public class EntryWorker : IWorkerService
	{
		private readonly ILogger<EntryWorker> _logger;
		private readonly ILicenseService _licenseService;
		private readonly InitializeWorker _initializeWorker;
		private readonly IServiceContainer _serviceContainer;
		private readonly IPlatformService _platformService;
		private readonly IReportingService _reportingService;
		public static readonly string WorkerName = $"{nameof(IWorkerService)}.Entry";

		public EntryWorker(ILogger<EntryWorker> logger, 
			ILicenseService licenseService,
			InitializeWorker initializeWorker,
			IServiceContainer serviceContainer,
			IPlatformService platformService,
			IReportingService reportingService)
		{
			_logger = logger;
			_licenseService = licenseService;
			_initializeWorker = initializeWorker;
			_serviceContainer = serviceContainer;
			_platformService = platformService;
			_reportingService = reportingService;
		}

		public void Run()
		{
			_logger.LogDebug("Run Entrypoint");
			if (!this._licenseService.TryInitializeLicense())
			{
				_logger.LogWarning("Lizenz ungültig");
				return;
			}
			
			// TODO: Update-Routine, am besten mit Signaturen, alles andere ist ein Security-Headshot

			try
			{
				_initializeWorker.Run();

				foreach (var platform in this._platformService.GetSyncPlatforms())
				{
					var worker = _serviceContainer.GetInstance<IPlatformWorkerService>();
					worker.Platform = platform;
					_logger.LogInformation($"Starte IPlatformWorkerService für {platform}");
					worker.Run();
				}
			}
			finally
			{
				_reportingService.SendFinishWorker();
			}
		}
	}
}