using System;
using Microsoft.Extensions.Logging;
using Moki11so.Shared.Dto;
using Moki11so.Shared.Essentials;
using MoSo.Connect.Service;

namespace MoSo.Connect.Worker
{
	public class PlatformWorker : IPlatformWorkerService
	{
		private readonly ILogger<PlatformWorker> _logger;
		private readonly IPlatformService _platformService;
		private readonly IOrdersService _ordersService;
		private readonly IShippingsService _shippingsService;
		private readonly IPaymentsService _paymentsService;
		private Platform? _platform;

		public PlatformWorker(ILogger<PlatformWorker> logger,
			IPlatformService platformService,
			IOrdersService ordersService,
			IShippingsService shippingsService,
			IPaymentsService paymentsService)
		{
			_logger = logger;
			_platformService = platformService;
			_ordersService = ordersService;
			_shippingsService = shippingsService;
			_paymentsService = paymentsService;
		}

		public void Run()
		{
			this._platformService.InitializeSync(this.Platform);

			var syncInfo = this._platformService.GetSyncInfo(this.Platform);

			this.TryImportOrders(syncInfo);
			this.TryExportOrders(syncInfo);
		}

		private void TryExportOrders(PlatformSyncInformation syncInfo)
		{
			if (syncInfo.ExportOrder || syncInfo.ExportDropshippingOrder)
			{
				_ordersService.ExportOrdersForPlatform(this.Platform);
			}

			if (syncInfo.ImportOrderShippingDetails)
			{
				this._shippingsService.ImportShippingForPlatform(this.Platform);
			}
		}

		private void TryImportOrders(PlatformSyncInformation syncInfo)
		{
			if (!syncInfo.ImportOrder)
			{
				return;
			}
			
			_ordersService.ImportOrdersForPlatform(this.Platform);

			if (syncInfo.ExportOrderShippingDetails)
			{
				_shippingsService.ExportShippingForPlatform(this.Platform);
			}
			
			if (syncInfo.ExportOrderShipper)
			{
				_shippingsService.ExportShippersForPlatform(this.Platform);
			}

			if (syncInfo.ImportOrderPayment)
			{
				_paymentsService.ImportPaymentsForPlatform(this.Platform);
			}

			if (syncInfo.ExportOrderCancellation)
			{
				_ordersService.ExportCancellationForPlatform(this.Platform);
			}
		}

		public Platform Platform
		{
			get => _platform ?? throw new Exception();
			set
			{
				if (_platform.HasValue)
					throw new Exception();
				_platform = value;
			}
		}
	}
}