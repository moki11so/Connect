namespace MoSo.Connect.Service
{
	public interface IDatabaseInfoService
	{
		string GetUsedSpace();
		SqlServerInfo GetSqlServerInfo();
		SqlSessionInfo GetSqlSessionInfo();
	}
}