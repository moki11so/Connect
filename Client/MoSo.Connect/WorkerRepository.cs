using LightInject;
using MoSo.Connect.Service;
using MoSo.Connect.Worker;

namespace MoSo.Connect
{
	public static class WorkerRepository
	{
		public static IWorkerService GetEntryService(this IServiceContainer serviceContainer)
		{
			return serviceContainer.GetInstance<IWorkerService>(EntryWorker.WorkerName);
		}
		
	}
}