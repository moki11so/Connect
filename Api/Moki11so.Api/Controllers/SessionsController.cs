using Microsoft.AspNetCore.Mvc;
using Moki11so.Shared.Dto;

namespace Moki11so.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SessionsController
	{

		[HttpGet]
		public SessionInformation GetSessionInfo()
		{
			return new SessionInformation
			{
				LicenseOwner = 1
			};
		}
		
	}
}