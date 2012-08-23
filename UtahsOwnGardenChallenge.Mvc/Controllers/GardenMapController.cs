using System;
using System.Collections.Generic;
using System.Data.Services.Client;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BingGeocoder;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.StorageClient;
using UtahsOwnGardenChallenge.Repositories;
using UtahsOwnGardenChallenge.Services;
using System.Web.Caching;

namespace UtahsOwnGardenChallenge.Mvc.Controllers
{
    public class GardenMapController : Controller
    {
        public Cache Cache { get; set; }
        private IGardenRepository GardenRepository { get; set; }
        public GardenMapController(IGardenRepository gardenRepository)
        {
            GardenRepository = gardenRepository;
            Cache = HttpRuntime.Cache;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MapInformation()
        {
            var zipcodes = GardenRepository.All().Select(c => c.ZipCode).Where(z => z.Length > 4 && z.StartsWith("84")).ToList();
            var distinctZipCodes = zipcodes.Distinct();
            var geocoder = new BingGeocoderClient("AlqLYGnwzgowzmozmv0Wy4TtXkoBLkAMAYKXu106gbu6O3MWj9jVpnHKVS20Obj-");

            var list = new List<ZipCodeData>();
            foreach (var zipcode in zipcodes.Distinct())
            {
                if (Cache[zipcode] == null)
                {
                    var result = geocoder.Geocode(zipcode);
                    if (!string.IsNullOrEmpty(result.Longitude) && !string.IsNullOrEmpty(result.Latitude))
                        Cache.Insert(zipcode, new ZipCodeData(zipcode, float.Parse(result.Latitude), float.Parse(result.Longitude), zipcodes.Count(z => z.Equals(zipcode))));
                }
                else
                {
                    var zipCodeData = (ZipCodeData)Cache[zipcode];
                    var zipCodeCount = zipcodes.Count(z => z == zipcode);
                    if (zipCodeData.Count != zipCodeCount)
                    {
                        zipCodeData.Count = zipCodeCount;
                        Cache[zipcode] = zipCodeData;
                    }
                }

                list.Add((ZipCodeData)Cache[zipcode]);
            }

            return Json(new
                            {
                                Result = list
                            }, JsonRequestBehavior.AllowGet);
        }

    }

    public class ZipCodeData
    {
        public ZipCodeData(string zipCode, float latitude, float longitude, int count)
        {
            ZipCode = zipCode;
            Latitude = latitude;
            Longitude = longitude;
            Count = count;
        }

        public string ZipCode { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public int Count { get; set; }
    }
}
