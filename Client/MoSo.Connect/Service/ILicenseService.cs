namespace MoSo.Connect.Service
{
	public interface ILicenseService
	{
		bool TryInitializeLicense();
		string GetLicenseHash();
	}
}