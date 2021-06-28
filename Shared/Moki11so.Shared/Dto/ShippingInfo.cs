using System;

namespace Moki11so.Shared.Dto
{
	public class ShippingInfo
	{
		public string PlatformOrderNumber { get; set; }
		public string TrackingCode { get; set; }
		public DateTime ShippedAt { get; set; }
		public string Carrier { get; set; }
		public string CarrierCode { get; set; }
	}
}