using System;
using System.ComponentModel.Design;
using System.Threading;
using System.Threading.Tasks;
using LightInject;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MoSo.Connect.Service;
using IServiceContainer = LightInject.IServiceContainer;

namespace MoSo.Connect.Worker
{
	public class TimedWorker : IHostedService, IDisposable
	{
		private readonly ILogger<TimedWorker> _logger;
		private readonly IServiceContainer _serviceContainer;
		private Timer _timer;
		private static object _lock = new object();
		private int _counter = 1;

		public TimedWorker(ILogger<TimedWorker> logger, IServiceContainer serviceContainer)
		{
			_logger = logger;
			_serviceContainer = serviceContainer;
		}

		public Task StartAsync(CancellationToken cancellationToken)
		{
			_timer = new Timer(DoWork, null, TimeSpan.FromSeconds(10), TimeSpan.FromMinutes(10));
			return Task.CompletedTask;
		}

		public Task StopAsync(CancellationToken cancellationToken)
		{
			_timer?.Change(Timeout.Infinite, 0);
			return Task.CompletedTask;
		}

		public void Dispose()
		{
			_timer?.Dispose();
		}

		private void DoWork(object state)
		{
			_logger.LogInformation($"Versuche nächten Durlauf zu starten. aktueller Zähler: {_counter}");
			if (Monitor.TryEnter(_lock))
			{
				try
				{
					_logger.LogInformation($"Durchlauf {_counter} startet");
					this.Run();
					_logger.LogInformation($"Durchlauf {_counter} erfolgreich beendet!");
				}
				catch (Exception e)
				{
					_logger.LogError(e, $"Durchlauf {_counter} erzeugte eine Ausnahme.");
				}
				finally
				{
					_counter++;
					Monitor.Exit(_lock);
				}
			}
		}

		private void Run()
		{
			_serviceContainer.GetEntryService().Run();
		}
		
	}
}