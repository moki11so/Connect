using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Moki11so.Shared.Drives;
using Moki11so.Shared.Workers;

namespace Moki11so.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ReportingController : ControllerBase
	{
		[HttpPut("internal")]
		public void SetWorkerInfos([FromBody] InternalWorkerInfo internalWorkerInfo)
		{
			
		}
		
		[HttpPut("wawi")]
		public void SetWorkerWorkerInfos([FromBody] WawiWorkerInfo wawiWorkerInfo)
		{
			
		}
		
		[HttpPut("meta")]
		public void SetMetaInfos([FromBody] MetaInfo metaInfo)
		{
			
		}
		
		[HttpPut("drives")]
		public void SetDrivesInfos([FromBody] IEnumerable<Drive> drives)
		{
			
		}
		
	}
}