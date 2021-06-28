using System.IO;
using System.Runtime.InteropServices;
using MoSo.Connect.Service;
using Newtonsoft.Json;

namespace MoSo.Connect.Concrete
{
	public class ConfigService : IConfigService
	{
		public Configuration GetConfig()
		{
			// TODO Encryped Config-File
			return JsonConvert.DeserializeObject<Configuration>(File.ReadAllText("config.json"));
		}

		public string GetBaseUrl()
		{
			//TODO: Aus einger Config auslesen
			return "https://localhost:5001/";
		}
	}
}