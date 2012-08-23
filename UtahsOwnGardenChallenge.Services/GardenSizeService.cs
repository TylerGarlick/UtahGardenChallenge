using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using UtahsOwnGardenChallenge.Repositories;

namespace UtahsOwnGardenChallenge.Services
{
	public interface IGardenSizeService
	{
		IEnumerable<SelectListItem> GetGardenSizeSelectList();
	}
	public class GardenSizeService : IGardenSizeService
	{
		protected IGardenSizeRepository GardenSizeRepository { get; private set; }

		public GardenSizeService(IGardenSizeRepository gardenSizeRepository)
		{
			GardenSizeRepository = gardenSizeRepository;
		}

		public IEnumerable<SelectListItem> GetGardenSizeSelectList()
		{
			return GardenSizeRepository.All().OrderBy(gs => gs.Ordinal).ToList().Select(gs => new SelectListItem() {Text = gs.Name, Value = gs.Id.ToString()});
		}
	}
}