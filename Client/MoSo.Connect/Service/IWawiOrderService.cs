using Moki11so.Shared.Essentials;

namespace MoSo.Connect.Service
{
	public interface IWawiOrderService
	{
		bool OrderExists(Platform platform, string platformOrderNumber, out string wawiOrderNumber);
		bool OrderCanceled(string wawiOrderNumber);
	}
}