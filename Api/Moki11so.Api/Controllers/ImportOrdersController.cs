using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Moki11so.Shared.Dto;
using Moki11so.Shared.Dto.Order;
using Moki11so.Shared.Essentials;

namespace Moki11so.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ImportOrdersController : ControllerBase
	{

		[HttpGet("{platform}")]
		[ProducesResponseType(201)]
		[ProducesResponseType(204)]
		public ActionResult<IEnumerable<ImportOrder>> GetOrders(Platform platform)
		{
			return NoContent();
		}

		[HttpGet("downloaded/{platform}")]
		[ProducesResponseType(201)]
		[ProducesResponseType(204)]
		public ActionResult<IEnumerable<string>> GetFinishedOrders(Platform platform)
		{
			return NoContent();
		}

		[HttpPut("downloaded")]
		public IActionResult UpdateOrder([FromBody] ImportOrderUpdate update)
		{
			return Ok();
		}

		[HttpPut("cancel")]
		public IActionResult CancelOrder([FromBody] ImportOrderCancellation cancel)
		{
			return Ok();
		}

		[HttpPut("shipping")]
		public IActionResult UpdateShippingInfo([FromBody] IEnumerable<ShippingInfo> shippingInfos)
		{
			return Ok();
		}
		
	}
}