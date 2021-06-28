using System;
using System.Collections.Generic;

namespace Moki11so.Shared.Dto.Order
{
	public class ImportOrder
	{
		public string PlatformOrderNumber { get; set; }
		public string WawiOrderNumber { get; set; }
		
		public int WawiFirma { get; set; }
		public int WawiPlatform { get; set; }
		public string WawiVersandart { get; set; }
		public DateTime CreatedAt { get; set; }
		public int WawiPaymentMethod { get; set; }

		public IEnumerable<ImportOrderPosition> Positions { get; set; }
	}

	public class ImportOrderPosition
	{
		public string Sku { get; set; }
		public decimal Quantity { get; set; }
		public decimal Price { get; set; }
		public decimal Discount { get; set; }
		public bool PriceExclVat { get; set; }
		public int WawiType { get; set; }
	}
}