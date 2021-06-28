using System;
using System.IO;
using System.Linq;
using Moki11so.Shared.Essentials;
using MoSo.Connect.Service;

namespace MoSo.Connect.Concrete
{
	public class FileCacheService : IFileCacheService
	{
		private readonly ILicenseService _licenseService;

		public FileCacheService(ILicenseService licenseService)
		{
			_licenseService = licenseService;
		}

		public void EnsureDirectoriesExists()
		{
			var hash = _licenseService.GetLicenseHash();
			var basePath = @"C:\Interface";
			Directory.CreateDirectory(basePath);
			var subDirectories = new[] {"Orders"};
			
			foreach (var platform in Enum.GetValues(typeof(Platform)).Cast<Platform>().Select(p => p.ToString()))
			{
				var platformPath = Path.Combine(basePath, platform);
				Directory.CreateDirectory(platformPath);
				var specificPlatformPath = Path.Combine(platformPath, hash);
				Directory.CreateDirectory(specificPlatformPath);

				foreach (var subDirectory in subDirectories)
				{
					var dir = Path.Combine(specificPlatformPath, subDirectory);
					Directory.CreateDirectory(dir);
				}
			}
		}

		public void WriteXmlOrderCache(Platform platform, string orderNumber, string content)
		{
			var dir = Path.Combine(@"C:\Interface", platform.ToString(), this._licenseService.GetLicenseHash(),
				"Orders");
			var file = Path.Combine(dir, "Bestellung_" + orderNumber + ".xml");
			File.WriteAllText(file, content);
		}

		public string GetXmlOrderFilePath(Platform platform, string orderNumber)
		{
			var dir = Path.Combine(@"C:\Interface", platform.ToString(), this._licenseService.GetLicenseHash(),
				"Orders");
			var file = Path.Combine(dir, "Bestellung_" + orderNumber + ".xml");
			if (!File.Exists(file))
				throw new Exception();
			return file;
		}
	}
}