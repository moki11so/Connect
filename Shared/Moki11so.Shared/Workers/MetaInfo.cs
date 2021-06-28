using System.Collections.Generic;

namespace Moki11so.Shared.Workers
{
	public class MetaInfo
	{
		public WawiClientConfig WawiClientConfig { get; set; }
		public IEnumerable<PaymentMethod> PaymentMethods { get; set; }
		public IEnumerable<ShippingMethod> ShippingMethods { get; set; }
		public IEnumerable<ShippingClass> ShippingClasses { get; set; }
		public IEnumerable<Company> Companies { get; set; }
		public IEnumerable<AmeiseTemplate> AmeiseExportTemplates { get; set; }
		public IEnumerable<AmeiseTemplate> AmeiseImportTemplates { get; set; }
		public IEnumerable<Shop> Shops { get; set; }
	}
}