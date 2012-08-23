using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using UtahsOwnGardenChallenge.Repositories;

namespace UtahsOwnGardenChallenge.Services
{
	public interface ICountyService
	{
		IEnumerable<SelectListItem> GetCountiesSelectList();
	}
	public class CountyService : ICountyService
	{
		protected ICountyRepository CountyRepository { get; private set; }

		public CountyService(ICountyRepository countyRepository)
		{
			CountyRepository = countyRepository;
		}

		public IEnumerable<SelectListItem> GetCountiesSelectList()
		{
			return CountyRepository.All().OrderBy(m => m.Name).ToList().Select(m => new SelectListItem() {Text = m.Name, Value = m.Id.ToString()});
		}
	}
}
