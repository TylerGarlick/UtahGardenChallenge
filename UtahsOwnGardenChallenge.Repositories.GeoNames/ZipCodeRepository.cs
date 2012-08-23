using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using UtahsOwnGardenChallenge.Repositories.Entities.ZipCodes;

namespace UtahsOwnGardenChallenge.Repositories.GeoNames
{
	public class ZipCodeRepository : IZipCodeRepository
	{
		public ZipCode GetZipcode(string zipcode)
		{
			var request = HttpWebRequest.Create(String.Format(@"http://api.geonames.org/postalCodeSearchJSON?postalcode={0}&country=US&maxRows=10&username=nexbusiness", zipcode));

			var response = request.GetResponse();

			if (response.ContentLength > 0)
			{
				var json = new StreamReader(response.GetResponseStream()).ReadToEnd();

				if (!String.IsNullOrEmpty(json))
				{
					var postCodeResponse = JsonConvert.DeserializeObject<PostalCodesResponse>(json);
					if (postCodeResponse != null)
					{
						return new ZipCode()
							   {
								   City = postCodeResponse.PlaceName,
								   Latitude = postCodeResponse.Lat,
								   Longitude = postCodeResponse.Lng,
								   State = postCodeResponse.AdminCode1,
								   Zip = postCodeResponse.PostalCode
							   };
					}
				}
			}
			return null;
		}
	}
}
