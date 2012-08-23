using System;
using System.Linq;
using System.Web.Mvc;
using UtahsOwnGardenChallenge.Repositories;

namespace UtahsOwnGardenChallenge.Mvc.Controllers
{
	public class CitiesController : Controller
	{
		protected ICountyRepository CountyRepository { get; set; }

		public CitiesController(ICountyRepository countyRepository)
		{
			CountyRepository = countyRepository;
		}

		public ActionResult ByCounty(Guid id)
		{
			var county = CountyRepository.ByKey(c => c.Id == id);
			return Json(new
			{
				Cities = county.Cities.OrderBy(m => m.Name).Select(c => new
														  {
															  Id = c.Id,
															  Name = c.Name
														  })
			}, JsonRequestBehavior.AllowGet);
		}

	}
}
