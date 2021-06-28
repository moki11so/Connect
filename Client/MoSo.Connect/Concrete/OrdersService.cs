using System.Collections.Generic;
using System.Linq;
using Moki11so.Shared.Dto.Order;
using Moki11so.Shared.Essentials;
using Moki11so.Shared.Orders;
using MoSo.Connect.Service;

namespace MoSo.Connect.Concrete
{
	public class OrdersService : IOrdersService
	{
		private readonly IFileCacheService _fileCacheService;
		private readonly IWawiOrderXmlService _wawiOrderXmlService;
		private readonly IClient _client;
		private readonly IWawiOrderService _wawiOrderService;
		private readonly IWawiXmlImportService _xmlImportService;

		public OrdersService(IFileCacheService fileCacheService, 
			IWawiOrderXmlService wawiOrderXmlService,
			IClient client,
			IWawiOrderService wawiOrderService,
			IWawiXmlImportService xmlImportService)
		{
			_fileCacheService = fileCacheService;
			_wawiOrderXmlService = wawiOrderXmlService;
			_client = client;
			_wawiOrderService = wawiOrderService;
			_xmlImportService = xmlImportService;
		}

		public void ImportOrdersForPlatform(Platform platform)
		{
			_fileCacheService.EnsureDirectoriesExists();
			var orders = _client.ApiImportorders(platform);

			foreach (var order in orders)
			{
				if (_wawiOrderService.OrderExists(platform, order.PlatformOrderNumber, out var wawiOrderNumber))
				{
					this._client.ApiImportordersDownloadedPut(new ImportOrderUpdate
					{
						WawiOrderNumber = wawiOrderNumber,
						Platform = platform,
					});
					continue;
				}
				
				var xml = _wawiOrderXmlService.GenerateAndGetXml(order);
				_fileCacheService.WriteXmlOrderCache(platform, order.PlatformOrderNumber, xml);
			}
			
			_xmlImportService.ImportOrders(platform, orders.Select(o => o.PlatformOrderNumber));

			foreach (var order in orders)
			{
				if (!_wawiOrderService.OrderExists(platform, order.PlatformOrderNumber, out var wawiOrderNumber))
				{
					continue;
				}

				this._client.ApiImportordersDownloadedPut(new ImportOrderUpdate
				{
					WawiOrderNumber = wawiOrderNumber,
					Platform = platform,
				});
			}
		}

		public void ExportOrdersForPlatform(Platform platform)
		{
			throw new System.NotImplementedException();
		}

		public void ExportCancellationForPlatform(Platform platform)
		{
			var platformOrderNumbers = _client.ApiImportordersDownloadedGet(platform);

			foreach (var platformOrderNumber in platformOrderNumbers)
			{
				var storno = !this._wawiOrderService.OrderExists(platform, platformOrderNumber, out var wawiOrderNumber);
				if (!storno)
				{
					storno = this._wawiOrderService.OrderCanceled(wawiOrderNumber);
				}

				if (!storno)
				{
					continue;
				}
				
				_client.ApiImportordersCancel(new ImportOrderCancellation
				{
					PlatformOrderNumber = platformOrderNumber,
					Platform = platform,
				});
			}
		}
	}
}