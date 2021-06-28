using Microsoft.AspNetCore.Mvc;
using Moki11so.Shared.Dto;
using Moki11so.Shared.Essentials;

namespace Moki11so.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SyncsController : ControllerBase
	{

		/// <response code="201">Sync-Flag gesetzt</response>  
		/// <response code="200">Sync-Flag vorhanden</response>  
		[HttpPut("{platform}")]
		[ProducesResponseType(201)]
		[ProducesResponseType(200)]
		public IActionResult InitializeSync(Platform platform)
		{
			return Ok();
		}

		[HttpGet("{platform}")]
		public ActionResult<PlatformSyncInformation> GetSyncInfo(Platform platform)
		{
			return Ok(new PlatformSyncInformation
			{

			});
		}
		
		
	}
}