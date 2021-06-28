using Moki11so.Shared.Essentials;

namespace MoSo.Connect.Service
{
	public interface IShippingsService
	{
		void ExportShippingForPlatform(Platform platform);
		void ExportShippersForPlatform(Platform platform);
		void ImportShippingForPlatform(Platform platform);
	}
}