using System.Collections.Generic;
using Moki11so.Shared.Dto;
using Moki11so.Shared.Essentials;
using MoSo.Connect.Service;

namespace MoSo.Connect.Concrete
{
	public class PlatformService : IPlatformService
	{
		public IEnumerable<Platform> GetSyncPlatforms()
		{
			throw new System.NotImplementedException();
		}

		public void EnsureWawiPlatformExists()
		{
			throw new System.NotImplementedException();
		}

		public void InitializeSync(Platform platform)
		{
			throw new System.NotImplementedException();
		}

		public PlatformSyncInformation GetSyncInfo(Platform platform)
		{
			throw new System.NotImplementedException();
		}
	}
}