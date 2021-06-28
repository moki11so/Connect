using System.Collections.Generic;
using Moki11so.Shared.Dto;
using Moki11so.Shared.Essentials;

namespace MoSo.Connect.Service
{
	public interface IWawiShippingService
	{
		IEnumerable<ShippingInfo> GetOrderShipping(string wawiOrderNumber);
	}
}