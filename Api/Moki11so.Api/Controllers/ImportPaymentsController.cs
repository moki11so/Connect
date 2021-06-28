using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Moki11so.Shared.Dto;
using Moki11so.Shared.Essentials;

namespace Moki11so.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ImportPaymentsController : ControllerBase
	{
		[HttpGet("{platform}")]
		public ActionResult<IEnumerable<ImportPayment>> GetPayments(Platform platform)
		{
			return NoContent();
		}

		[HttpPut("downloaded")]
		public IActionResult UpdateOrder([FromBody] ImportPayment payment)
		{
			return Ok();
		}
	}
}