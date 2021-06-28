using System.Net.Http;
using System.Runtime.CompilerServices;
using LightInject;
using MoSo.Connect.Concrete;
using MoSo.Connect.Concrete.Wawi;
using MoSo.Connect.Service;
using MoSo.Connect.Worker;

namespace MoSo.Connect
{
	public static class Initializer
	{
		private static string LicenseKey = string.Empty;
		
		public static void InitializeServices(this IServiceRegistry serviceRegistry)
		{
			serviceRegistry.Register<IWorkerService, EntryWorker>(EntryWorker.WorkerName);
			serviceRegistry.Register<IWorkerService, InitializeWorker>(InitializeWorker.WorkerName);

			serviceRegistry.Register<IPlatformWorkerService, PlatformWorker>();
			
			serviceRegistry.Register<WawiDatabaseService>();
			serviceRegistry.Register<IConfigService, ConfigService>();
			serviceRegistry.Register<IDatabaseInfoService, DatabaseInfoService>();
			serviceRegistry.Register<IFileCacheService, FileCacheService>();
			serviceRegistry.Register<ILicenseService, LicenseService>();
			serviceRegistry.Register<IOrdersService, OrdersService>();
			serviceRegistry.Register<IPaymentsService, PaymentsService>();
			serviceRegistry.Register<IPlatformService, PlatformService>();
			serviceRegistry.Register<IReportingService, ReportingService>();
			serviceRegistry.Register<IShippingsService, ShippingsService>();
			
			serviceRegistry.Register<IWawiInfoService, WawiInfoService>();
			serviceRegistry.Register<IWawiLieferantenService, WawiLieferantenService>();
			serviceRegistry.Register<IWawiOrderService, WawiOrderService>();
			//TODO: serviceRegistry.Register<IWawiOrderXmlService, WawiOrderXmlService>();
			serviceRegistry.Register<IWawiPaymentService, WawiPaymentService>();
			serviceRegistry.Register<IWawiShippingService, WawiShippingService>();
			//TODO: serviceRegistry.Register<IWawiXmlImportService, WawiXmlImportService>();

			serviceRegistry.Register<IClient, Client.Client>((f, i) =>
			{
				var httpClient = new HttpClient();
				httpClient.DefaultRequestHeaders.Add("X-MoSo-Authorization", LicenseKey);
				var config = f.GetInstance<IConfigService>();
				return new Client.Client(config.GetBaseUrl(), httpClient);
			});

		}

		public static void AuthorizeClients(string licenseKey)
		{
			LicenseKey = licenseKey;
		}
	}
}