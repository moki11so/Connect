using Moki11so.Shared.Essentials;

namespace Moki11so.Shared.Dto
{
	public class ImportPayment
	{
		public string PlatformOrderNumber { get; set; }
		public Platform Platform { get; set; }
		public string PaymentId { get; set; }
		public string Provider { get; set; }
		public decimal Total { get; set; }
	}
}