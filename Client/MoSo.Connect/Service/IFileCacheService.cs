using Moki11so.Shared.Essentials;

namespace MoSo.Connect.Service
{
	public interface IFileCacheService
	{
		void EnsureDirectoriesExists();
		void WriteXmlOrderCache(Platform platform, string orderNumber, string content);
		string GetXmlOrderFilePath(Platform platform, string orderNumber);
	}
}