using System.Collections.Generic;
using Moki11so.Shared.Dto;
using Moki11so.Shared.Essentials;

namespace MoSo.Connect.Service
{
	public interface IPlatformService
	{
		IEnumerable<Platform> GetSyncPlatforms();
		void EnsureWawiPlatformExists();
		void InitializeSync(Platform platform);
		PlatformSyncInformation GetSyncInfo(Platform platform);
	}
}