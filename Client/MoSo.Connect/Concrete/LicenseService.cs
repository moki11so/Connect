using System;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Logging;
using Moki11so.Shared.Dto;
using MoSo.Connect.Service;

namespace MoSo.Connect.Concrete
{
	public class LicenseService : ILicenseService
	{
		private readonly ILogger<LicenseService> _logger;
		private readonly IWawiLieferantenService _wawiLieferantenService;

		public LicenseService(ILogger<LicenseService> logger,
			IWawiLieferantenService wawiLieferantenService)
		{
			_logger = logger;
			_wawiLieferantenService = wawiLieferantenService;
		}

		public bool TryInitializeLicense()
		{
			var licenseKey = _wawiLieferantenService.FindLicenseKey();
			if (string.IsNullOrWhiteSpace(licenseKey))
			{
				_logger.LogWarning("Kein Lizenzschlüssel in der angegebenen Datenbank gefunden");
				return false;
			}
			
			// TODO: Hole Sitzung
			var session = new SessionInformation();

			if (!session.LicenseOwner.HasValue)
			{
				_logger.LogWarning("Zu Ihrer Lizenz wurde leider kein passender Mandant gefunden");
				return false;
			}
			
			Initializer.AuthorizeClients(licenseKey);
			return true;
		}

		public string GetLicenseHash()
		{
			var s = ReverseString(_wawiLieferantenService.FindLicenseKey().Substring(0, 10));
			using var shA1Managed = new SHA1Managed();
			var hash = shA1Managed.ComputeHash(Encoding.UTF8.GetBytes(s));
			var stringBuilder = new StringBuilder(hash.Length * 2);
			foreach (var num in hash)
				stringBuilder.Append(num.ToString("X2"));
			return stringBuilder.ToString().ToLower();
		}
		
		private static string ReverseString(string s)
		{
			var charArray = s.ToCharArray();
			Array.Reverse(charArray);
			return new string(charArray);
		}
	}
}