using Moki11so.Shared.Essentials;

namespace MoSo.Connect.Service
{
	public interface IPlatformWorkerService : IWorkerService
	{
		Platform Platform { get; set; }
	}
}