namespace UtahsOwnGardenChallenge.Repositories.GeoNames
{
	public class PostalCodesResponse
	{
		//{"postalCodes":[{"adminName2":"Davis","adminCode2":"011","adminCode1":"UT","postalCode":"84015","countryCode":"US","lng":-112.048224,"placeName":"Clearfield","lat":41.129388,"adminName1":"Utah"}]}
		public string PostalCode { get; set; }
		public string CountryCode { get; set; }
		public string PlaceName { get; set; }
		public string AdminName1 { get; set; }
		public string AdminName2 { get; set; }
		public string AdminCode1 { get; set; }
		public float Lng { get; set; }
		public float Lat { get; set; }
	}
}