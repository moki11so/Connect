using System.Collections.Generic;
using System.Linq;
using Dapper;
using Moki11so.Shared.Dto;
using MoSo.Connect.Service;

namespace MoSo.Connect.Concrete.Wawi
{
	public class WawiShippingService : IWawiShippingService
	{
		private readonly WawiDatabaseService _databaseService;

		public WawiShippingService(WawiDatabaseService databaseService)
		{
			_databaseService = databaseService;
		}

		public IEnumerable<ShippingInfo> GetOrderShipping(string wawiOrderNumber)
		{
			using var c = _databaseService.GetSqlConnection();
			return c.Query<ShippingInfo>(WawiSqlCommands.ShippingByBestellNr, new
			{
				BestellNr = wawiOrderNumber
			}).ToList();
		}
	}
}