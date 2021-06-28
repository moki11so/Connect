using System.Collections.Generic;
using Dapper;
using Moki11so.Shared.Workers;
using MoSo.Connect.Service;

namespace MoSo.Connect.Concrete.Wawi
{
	public class WawiInfoService : IWawiInfoService
	{
		private readonly WawiDatabaseService _databaseService;

		public WawiInfoService(WawiDatabaseService databaseService)
		{
			_databaseService = databaseService;
		}

		public string GetVersion()
		{
			using var c = _databaseService.GetSqlConnection();
			return c.ExecuteScalar<string>(WawiSqlCommands.Version);
		}

		public WawiWorkerInfo GetWawiWorkerInfo()
		{
			using var c = _databaseService.GetSqlConnection();
			var info = c.QueryFirst<WawiWorkerInfo>(WawiSqlCommands.WorkerInfo);
			info.Options = c.QueryFirstOrDefault<WawiWorkerOptions>(WawiSqlCommands.WorkerOptions);
			return info;
		}

		public WawiClientConfig GetClientConfig()
		{
			using var c = _databaseService.GetSqlConnection();
			return c.QueryFirst<WawiClientConfig>(WawiSqlCommands.ClientConfig);
		}

		public IEnumerable<Company> GetCompanies()
		{
			return this.QueryAll<Company>(WawiSqlCommands.Companies);
		}

		public IEnumerable<Shop> GetShops()
		{
			return this.QueryAll<Shop>(WawiSqlCommands.Shops);
		}

		public IEnumerable<PaymentMethod> GetPaymentMethods()
		{
			return this.QueryAll<PaymentMethod>(WawiSqlCommands.PaymentMethods);
		}

		public IEnumerable<ShippingClass> GetShippingClasses()
		{
			return this.QueryAll<ShippingClass>(WawiSqlCommands.ShippingClasses);
		}

		public IEnumerable<ShippingMethod> GetShippingMethods()
		{
			return this.QueryAll<ShippingMethod>(WawiSqlCommands.ShippingMethods);
		}

		public IEnumerable<AmeiseTemplate> GetAmeiseExportTemplates()
		{
			return this.QueryAll<AmeiseTemplate>(WawiSqlCommands.AmeiseExportTemplates);
		}

		public IEnumerable<AmeiseTemplate> GetAmeiseImportTemplates()
		{
			return this.QueryAll<AmeiseTemplate>(WawiSqlCommands.AmeiseImportTemplates);
		}

		private IEnumerable<T> QueryAll<T>(string sql) where T : class
		{
			using var c = _databaseService.GetSqlConnection();
			return c.Query<T>(sql);
		}
	}
}