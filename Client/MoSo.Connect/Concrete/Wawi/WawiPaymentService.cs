using Dapper;
using MoSo.Connect.Service;

namespace MoSo.Connect.Concrete.Wawi
{
	public class WawiPaymentService : IWawiPaymentService
	{
		private readonly WawiDatabaseService _wawiDatabaseService;

		public WawiPaymentService(WawiDatabaseService wawiDatabaseService)
		{
			_wawiDatabaseService = wawiDatabaseService;
		}

		public bool HasPayments(string wawiOrderNumber)
		{
			using var c = _wawiDatabaseService.GetSqlConnection();
			return c.ExecuteScalar<int>(WawiSqlCommands.CountOrdersWithPaymentsByBestellNr, new
			{
				BestellNr = wawiOrderNumber
			}) > 0;
		}

		public void CreatePayment(WawiPayment payment)
		{
			using var c = _wawiDatabaseService.GetSqlConnection();
			c.Execute(WawiSqlCommands.InsertPayment, payment);
		}
	}
}