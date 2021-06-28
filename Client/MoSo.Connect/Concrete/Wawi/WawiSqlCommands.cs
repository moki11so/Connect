namespace MoSo.Connect.Concrete.Wawi
{
	internal static class WawiSqlCommands
	{
		public const string LicenseKeyQuery = @"SELECT cLiefNr FROM tlieferant WHERE cFirma = 'modernsolution'";

		public const string OrderNumberByInetBestellNr =
			@"SELECT cBestellNr FROM tBestellung WHERE cInetBestellNr=@cInetBestellNr";

		public const string CountOrdersNotCancelledByBestellNr =
			@"SELECT COUNT(1) FROM tBestellung WHERE cBestellNr=@BestellNr AND nStorno<>1";

		public const string CountOrdersWithPaymentsByBestellNr =
			@"SELECT COUNT(1)
FROM tZahlung
JOIN tBestellung ON tBestellung.kBestellung = tZahlung.kBestellung
WHERE tBestellung.cBestellNr=@BestellNr";

		public const string InsertPayment =
			@"INSERT INTO tZahlung (kZahlung, cName, dDatum, fBetrag, kBestellung, kBenutzer, nAnzahlung, cHinweis, kZahlungsart, nKeinExport, cSKRManuell, cExternalTransactionId, kZahlungsabgleichUmsatz, nZuweisungstyp, nZahlungstyp, cZuweisungsinfo, nZuweisungswertung, kGutschrift, kEingangsrechnung) VALUES ((SELECT MAX(kZahlung)+ 1 FROM tZahlung), @Name, GETDATE(), @Total, (SELECT kBestellung FROM tBestellung WHERE cBestellNr = @WawiOrderNumber), 1, 0, '', (SELECT TOP 1 tZa.kZahlungsart
FROM (SELECT TOP(1) kZahlungsart 
FROM tZahlungsart 
WHERE cName LIKE @Name
UNION
SELECT 0 AS kZahlungsart) AS tZa
ORDER BY tZa.kZahlungsart DESC), 0, '', @ExternalTransactionId, 0, 0, 0, '', 0, 0, NULL);";

		public const string ShippingByBestellNr =
			@"SELECT	tBestellung.cInetBestellNr AS PlatformOrderNumber,
		tVersand.cIdentCode AS TrackingCode,
		tVersand.dErstellt AS ShippedAt,
		tversandart.cName AS Carrier,
		tversandart.cAmazonCarrierCode AS CarrierCode
FROM tBestellung
JOIN tLieferschein ON tLieferschein.kBestellung = tBestellung.kBestellung
JOIN tVersand ON tVersand.kLieferschein = tLieferschein.kLieferschein
JOIN tversandart ON tversandart.kVersandArt = tVersand.kVersandArt
WHERE tBestellung.cBestellNr=@BestellNr";

		public const string Version = @"SELECT cVersion FROM tversion";
		
		public const string WorkerInfo = @"SELECT TOP 1
	nEbayPID AS EbayProcess,
	dEbayStart AS EbayStartAt,
	dEbayEnde AS EbayEndeAt,
	nAmazonPID AS AmazonProcess,
	dAmazonStart AS AmazonStartAt,
	dAmazonEnde AS AmazonEndeAt,
	nShopPID AS ShopProcess,
	dShopStart AS ShopStartAt,
	dShopEnde AS ShopEndeAt
FROM tWorkerInfo";
		
		public const string WorkerOptions = @"SELECT nSek AS Sek,
		nKeinShop AS KeinShop,
		nKeinEbay AS KeinEbay,
		nKeinAmazon AS KeinAmazon
FROM (SELECT TOP 1
	nSek,
	nKeinShop,
    nKeinEbay,
    nKeinAmazon,
    1 AS nSort
FROM tHintergrundDienst
UNION
SELECT 0 AS nSek,
	0 AS nKeinShop,
    0 AS nKeinEbay,
    0 AS nKeinAmazon,
    0 AS nSort) AS tHD
ORDER BY nSort DESC";
		
		public const string ClientConfig = @"SELECT TOP(1)
	cEMail AS Email,
	cWWW AS Url
FROM tfirma";
		
		public const string Companies = @"SELECT kFirma AS Id, cName AS Name FROM tfirma";
		public const string Shops = @"SELECT kShop AS Id, cName AS Name, nTyp AS Type FROM tShop";
		public const string PaymentMethods = @"SELECT kZahlungsart AS Id, cName AS Name FROM tZahlungsart";
		public const string ShippingMethods = @"SELECT kVersandArt AS Id, cName AS Name FROM tversandart";
		public const string ShippingClasses = @"SELECT kVersandklasse AS Id, cName AS Name FROM tVersandklasse";
		public const string AmeiseExportTemplates = @"SELECT kExportVorlage AS Id, cName AS Name, kExportTyp AS Type FROM ameise_exportvorlage WHERE nDeleted=0";
		public const string AmeiseImportTemplates = @"SELECT kImportVorlage AS Id, cName AS Name, kImportTyp AS Type FROM ameise_importvorlage WHERE nDeleted=0";
	}
}