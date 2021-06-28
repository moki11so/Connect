namespace Moki11so.Shared.Dto
{
	public class PlatformSyncInformation
	{
		public bool ImportOrder { get; set; }
		public bool ExportOrderShippingDetails { get; set; }
		public bool ExportOrderShipper { get; set; }
		public bool ExportOrderCancellation { get; set; }
		public bool ImportOrderPayment { get; set; }
		
		public bool ExportOrder { get; set; }
		public bool ExportDropshippingOrder { get; set; }
		public bool ImportOrderShippingDetails { get; set; }
	}
}