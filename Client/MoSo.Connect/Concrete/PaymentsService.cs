using Microsoft.Extensions.Logging;
using Moki11so.Shared.Essentials;
using MoSo.Connect.Service;

namespace MoSo.Connect.Concrete
{
	public class PaymentsService : IPaymentsService
	{
		private readonly ILogger<PaymentsService> _logger;
		private readonly IClient _client;
		private readonly IWawiOrderService _wawiOrderService;
		private readonly IWawiPaymentService _wawiPaymentService;

		public PaymentsService(ILogger<PaymentsService> logger,
			IClient client,
			IWawiOrderService wawiOrderService,
			IWawiPaymentService wawiPaymentService)
		{
			_logger = logger;
			_client = client;
			_wawiOrderService = wawiOrderService;
			_wawiPaymentService = wawiPaymentService;
		}

		public void ImportPaymentsForPlatform(Platform platform)
		{
			var payments = _client.ApiImportpayments(platform);

			foreach (var payment in payments)
			{
				if (!_wawiOrderService.OrderExists(platform, payment.PlatformOrderNumber, out var wawiOrderNumber))
				{
					continue;
				}

				if (_wawiPaymentService.HasPayments(wawiOrderNumber))
				{
					continue;
				}

				_wawiPaymentService.CreatePayment(new WawiPayment
				{
					WawiOrderNumber = wawiOrderNumber,
					Name = payment.Provider,
					Total = payment.Total,
					ExternalTransactionId = payment.PaymentId,
				});
				
				_client.ApiImportpaymentsDownloaded(payment);
			}
		}
	}
}