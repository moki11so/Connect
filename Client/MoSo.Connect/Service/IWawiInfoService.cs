using System.Collections.Generic;
using Moki11so.Shared.Workers;

namespace MoSo.Connect.Service
{
	public interface IWawiInfoService
	{
		string GetVersion();
		WawiWorkerInfo GetWawiWorkerInfo();
		WawiClientConfig GetClientConfig();
		IEnumerable<Company> GetCompanies();
		IEnumerable<Shop> GetShops();
		IEnumerable<PaymentMethod> GetPaymentMethods();
		IEnumerable<ShippingClass> GetShippingClasses();
		IEnumerable<ShippingMethod> GetShippingMethods();
		IEnumerable<AmeiseTemplate> GetAmeiseExportTemplates();
		IEnumerable<AmeiseTemplate> GetAmeiseImportTemplates();
	}
}