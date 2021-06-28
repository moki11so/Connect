using Moki11so.Shared.Dto.Order;
using Moki11so.Shared.Orders;

namespace MoSo.Connect.Service
{
	public interface IWawiOrderXmlService
	{
		public string GenerateAndGetXml(ImportOrder order);
	}
}