using Dapper;
using MoSo.Connect.Concrete.Wawi;
using MoSo.Connect.Service;

namespace MoSo.Connect.Concrete
{
	public class DatabaseInfoService : IDatabaseInfoService
	{
		private readonly WawiDatabaseService _databaseService;

		public DatabaseInfoService(WawiDatabaseService databaseService)
		{
			_databaseService = databaseService;
		}

		public string GetUsedSpace()
		{
			using var c = _databaseService.GetSqlConnection();
			return c.ExecuteScalar<string>(
				"SELECT CONVERT(DECIMAL(10,2),(SUM(size * 8.00) / 1024.00)) As UsedSpaceInMB FROM master.sys.master_files");
		}

		public SqlServerInfo GetSqlServerInfo()
		{
			using var c = _databaseService.GetSqlConnection();
			return c.QueryFirst<SqlServerInfo>(
				@"SELECT SERVERPROPERTY('MachineName') AS SqlServerName,
SERVERPROPERTY('InstanceName') AS SqlInstanceName,
SERVERPROPERTY('Edition') AS SqlEdition,
SERVERPROPERTY('ProductVersion') AS SqlVersion,
Left(@@Version, Charindex('-', @@version) - 2) As SqlVersionName");
		}

		public SqlSessionInfo GetSqlSessionInfo()
		{
			using var c = _databaseService.GetSqlConnection();
			return c.QueryFirst<SqlSessionInfo>(
				@"SELECT TOP(1) DB_NAME(dbid) as SqlDb, 
COUNT(dbid) as SqlConnections
FROM sys.sysprocesses WHERE dbid > 0 AND DB_NAME(dbid) NOT LIKE 'master' AND DB_NAME(dbid) NOT LIKE 'msdb' GROUP BY dbid");
		}
	}
}