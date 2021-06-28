using System.Collections.Generic;
using Moki11so.Shared.Dto.Order;
using Moki11so.Shared.Essentials;

namespace MoSo.Connect.Service
{
	public interface IWawiXmlImportService
	{
		void ImportOrders(Platform platform, IEnumerable<string> platformOrderIds);
	}
}