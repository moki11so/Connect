using Moki11so.Shared.Essentials;

namespace MoSo.Connect.Service
{
	public interface IPaymentsService
	{
		void ImportPaymentsForPlatform(Platform platform);
	}
}