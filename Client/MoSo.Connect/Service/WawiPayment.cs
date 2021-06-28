namespace MoSo.Connect.Service
{
	public class WawiPayment
	{
		public string WawiOrderNumber { get; set; }
		public string Name { get; set; }
		public decimal Total { get; set; }
		public string ExternalTransactionId { get; set; }
	}
}