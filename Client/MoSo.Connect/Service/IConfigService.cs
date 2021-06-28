namespace MoSo.Connect.Service
{
	public interface IConfigService
	{
		Configuration GetConfig();
		string GetBaseUrl();
	}
}