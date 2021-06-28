using System.Data.SqlClient;
using MoSo.Connect.Service;

namespace MoSo.Connect.Concrete.Wawi
{
	public class WawiDatabaseService
	{
		private readonly IConfigService _configService;

		public WawiDatabaseService(IConfigService configService)
		{
			_configService = configService;
		}

		public SqlConnection GetSqlConnection()
		{
			var config = _configService.GetConfig();
			return new SqlConnection(new SqlConnectionStringBuilder
			{
				DataSource = config.WawiServer,
				InitialCatalog = config.WawiDatabase,
				UserID = config.WawiUser,
				Password = config.WawiPassword,
				ConnectTimeout = 600
			}.ConnectionString);
		}
	}
}