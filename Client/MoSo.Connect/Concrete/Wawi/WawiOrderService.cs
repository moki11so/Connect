using Dapper;
using Moki11so.Shared.Essentials;
using MoSo.Connect.Service;

namespace MoSo.Connect.Concrete.Wawi
{
	public class WawiOrderService : IWawiOrderService
	{
		private readonly WawiDatabaseService _wawiDatabaseService;

		public WawiOrderService(WawiDatabaseService wawiDatabaseService)
		{
			_wawiDatabaseService = wawiDatabaseService;
		}

		public bool OrderExists(Platform platform, string platformOrderNumber, out string wawiOrderNumber)
		{
			using var c = _wawiDatabaseService.GetSqlConnection();
			wawiOrderNumber = c.ExecuteScalar<string>(WawiSqlCommands.OrderNumberByInetBestellNr, new
			{
				cInetBestellNr = $"{platform.ToString()}_{platformOrderNumber}"
			});
			return !string.IsNullOrWhiteSpace(wawiOrderNumber);
		}

		public bool OrderCanceled(string wawiOrderNumber)
		{
			using var c = _wawiDatabaseService.GetSqlConnection();
			var count = c.ExecuteScalar<int>(WawiSqlCommands.CountOrdersNotCancelledByBestellNr, new
			{
				BestellNr = wawiOrderNumber
			});
			return count == 0;
		}
	}
}