using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Moki11so.Shared.Essentials;

namespace Moki11so.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PlatformsController : ControllerBase
	{

		[HttpGet("sync")]
		[ProducesResponseType(200)]
		public IEnumerable<Platform> GetSyncPlatforms()
		{
			return new[] {Platform.Crowdfox};
		}
		
	}
}