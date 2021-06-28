using Moki11so.Shared.Essentials;

namespace MoSo.Connect.Service
{
	public interface IOrdersService
	{
		void ImportOrdersForPlatform(Platform platform);
		void ExportOrdersForPlatform(Platform platform);
		void ExportCancellationForPlatform(Platform platform);
	}
}