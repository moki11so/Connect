using System.Collections.Generic;
using System.Linq;
using LightInject;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MoSo.Connect.Service;

namespace MoSo.Connect.Worker
{
	public class Program
	{
		public static void Main(string[] args)
		{
			CreateHostBuilder(args).Build().Run();
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.UseWindowsService()
				.UseLightInject()
				.ConfigureContainer<IServiceContainer>((hostContext, container) =>
				{
					container.RegisterFrom<CompositionRoot>();
					container.Register<IServiceContainer>((f) => container);
				})
				.ConfigureServices((hostContext, services) =>
				{
					services.AddHostedService<TimedWorker>();
				});
	}
	
	public class CompositionRoot : ICompositionRoot
	{
		public void Compose(IServiceRegistry serviceRegistry)
		{
			serviceRegistry.InitializeServices();
		}
	}

	
}