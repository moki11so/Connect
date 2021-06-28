using Moki11so.Shared.Essentials;

namespace Moki11so.Shared.Dto.Order
{
	public class ImportOrderUpdate
	{
		public string PlatformOrderNumber { get; set; }
		public string WawiOrderNumber { get; set; }
		public Platform Platform { get; set; }
	}

	public class ImportOrderCancellation
	{
		public string PlatformOrderNumber { get; set; }
		public Platform Platform { get; set; }
	}
}