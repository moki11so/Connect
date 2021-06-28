using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Moki11so.Api.Authorization
{
	public class ApiKeyMiddleware
	{
		private readonly RequestDelegate _next;
		private const string ApiKeyName = "X-MoSo-Authorization";
		public ApiKeyMiddleware(RequestDelegate next)
		{
			_next = next;
		}
		public async Task InvokeAsync(HttpContext context)
		{
			if (!context.Request.Headers.TryGetValue(ApiKeyName, out var extractedApiKey))
			{
				context.Response.StatusCode = 401;
				await context.Response.WriteAsync("Api Key was not provided.");
				return;
			}
 
			// TODO: Hier Prüfung auf API-Key/Lizenz einbauen und z.B. in einen Scoped-Service schreiben!
			if (extractedApiKey != "1234")
			{
				context.Response.StatusCode = 401;
				await context.Response.WriteAsync("Unauthorized client.");
				return;
			}
 
			await _next(context);
		}
	}
}