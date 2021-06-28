using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.Win32;
using Moki11so.Shared.Drives;
using Moki11so.Shared.Workers;
using MoSo.Connect.Service;

namespace MoSo.Connect.Concrete
{
	public class ReportingService : IReportingService
	{
		private readonly IClient _client;
		private readonly ILogger<ReportingService> _logger;
		private readonly IWawiInfoService _wawiInfoService;
		private readonly IDatabaseInfoService _databaseInfoService;

		public ReportingService(IClient client,
			ILogger<ReportingService> logger,
			IWawiInfoService wawiInfoService,
			IDatabaseInfoService databaseInfoService)
		{
			_client = client;
			_logger = logger;
			_wawiInfoService = wawiInfoService;
			_databaseInfoService = databaseInfoService;
		}

		public void SendInitialWorkerInfos()
		{
			var sqlServerInfo = _databaseInfoService.GetSqlServerInfo();
			var sqlSessionInfo = _databaseInfoService.GetSqlSessionInfo();
			
			_client.ApiReportingInternal(new InternalWorkerInfo
			{
				Version = 0.854f,
				LastConnectAt = DateTime.Now,
				WawiVersion = _wawiInfoService.GetVersion(),
				ServerName = Environment.MachineName,
				OperatingSystem = GetWindowsPlatform(),
				SqlUsedSpace = _databaseInfoService.GetUsedSpace(),
				
				SqlServerName = sqlServerInfo.SqlServerName,
				SqlInstanceName = sqlServerInfo.SqlInstanceName,
				SqlEdition = sqlServerInfo.SqlEdition,
				SqlVersion = sqlServerInfo.SqlVersion,
				SqlVersionName = sqlServerInfo.SqlVersionName,
				
				SqlDb = sqlSessionInfo.SqlDb,
				SqlConnections = sqlSessionInfo.SqlConnections,
			});
		}

		public void SendInitialWawiWorkerInfos()
		{
			_client.ApiReportingWawi(_wawiInfoService.GetWawiWorkerInfo());
		}

		public void SendMetaInfos()
		{
			_client.ApiReportingMeta(new MetaInfo
			{
				WawiClientConfig = _wawiInfoService.GetClientConfig(),
				Companies = _wawiInfoService.GetCompanies(),
				Shops = _wawiInfoService.GetShops(),
				PaymentMethods = _wawiInfoService.GetPaymentMethods(),
				ShippingClasses = _wawiInfoService.GetShippingClasses(),
				ShippingMethods = _wawiInfoService.GetShippingMethods(),
				AmeiseExportTemplates = _wawiInfoService.GetAmeiseExportTemplates(),
				AmeiseImportTemplates = _wawiInfoService.GetAmeiseImportTemplates(),
			});
		}

		public void SendDriveInfos()
		{
			var drives = DriveInfo.GetDrives();
			var driveList = new List<Drive>();
			var i = 0;
			foreach (var driveInfo in drives.Where(d => d.IsReady && d.DriveType == DriveType.Fixed))
			{
				driveList.Add(new Drive
				{
					Fixed = true,
					InUse = i == 0,
					Name=driveInfo.Name,
					TotalSize = driveInfo.TotalSize, 
					AvailableFreeSpace = driveInfo.AvailableFreeSpace
				});
				i++;
			}
			
			_client.ApiReportingDrives(driveList);
		}

		public void SendFinishWorker()
		{
			_client.ApiReportingInternal(new InternalWorkerInfo
			{
				LastFinishAt =  DateTime.Now,
			});
		}
		
		
		private static string GetWindowsPlatform()
		{
			string name = "SOFTWARE\\Wow6432Node\\Microsoft\\Windows NT\\CurrentVersion";
			return Registry.LocalMachine.OpenSubKey(name).GetValue("ProductName").ToString();
		}
	}
}