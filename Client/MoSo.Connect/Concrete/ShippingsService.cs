using System;
using System.Collections.Generic;
using System.Linq;
using Moki11so.Shared.Dto;
using Moki11so.Shared.Essentials;
using MoSo.Connect.Service;

namespace MoSo.Connect.Concrete
{
	public class ShippingsService : IShippingsService
	{
		private readonly IClient _client;
		private readonly IWawiOrderService _wawiOrderService;
		private readonly IWawiShippingService _wawiShippingService;

		public ShippingsService(IClient client,
			IWawiOrderService wawiOrderService,
			IWawiShippingService wawiShippingService)
		{
			_client = client;
			_wawiOrderService = wawiOrderService;
			_wawiShippingService = wawiShippingService;
		}

		public void ExportShippingForPlatform(Platform platform)
		{
			var platformOrderNumbers = _client.ApiImportordersDownloadedGet(platform);

			foreach (var platformOrderNumber in platformOrderNumbers)
			{
				if (!this._wawiOrderService.OrderExists(platform, platformOrderNumber, out var wawiOrderNumber))
				{
					continue;
				}

				var shipping = _wawiShippingService.GetOrderShipping(wawiOrderNumber)?.ToArray();
				if (shipping == null || !shipping.Any())
				{
					continue;
				}

				foreach (var info in shipping)
				{
					info.PlatformOrderNumber = info.PlatformOrderNumber.Substring(platform.ToString().Length + 1);
				}
				
				_client.ApiImportordersShipping(shipping);
			}
		}

		[Obsolete]
		public void ExportShippersForPlatform(Platform platform)
		{
			throw new Exception();
		}

		public void ImportShippingForPlatform(Platform platform)
		{
			throw new System.NotImplementedException();
		}
	}
}