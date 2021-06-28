using System;
using Moki11so.Shared.Essentials;

namespace Moki11so.Shared.Orders
{
	public class CancelInfo
	{
		public int OrderId { get; set; }
		public Platform Platform { get; set; }
		public DateTime CanceledAt { get; set; }
	}
}