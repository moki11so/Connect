using Dapper;
using MoSo.Connect.Service;

namespace MoSo.Connect.Concrete.Wawi
{
	public class WawiLieferantenService : IWawiLieferantenService
	{
		private readonly WawiDatabaseService _databaseService;

		public WawiLieferantenService(WawiDatabaseService databaseService)
		{
			_databaseService = databaseService;
		}

		public string FindLicenseKey()
		{
			using var c = _databaseService.GetSqlConnection();
			return c.QueryFirstOrDefault<LicenseKeyContainer>(WawiSqlCommands.LicenseKeyQuery)?.cLiefNr;
		}

		private class LicenseKeyContainer
		{
			public string cLiefNr { get; set; }
		}
	}
}