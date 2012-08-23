using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using UtahsOwnGardenChallenge.Repositories;

namespace UtahsOwnGardenChallenge.Services
{
	public interface IGardenTypeService
	{
		IEnumerable<SelectListItem> GetGardenTypesSelectList();
	}
	public class GardenTypeService : IGardenTypeService
	{
		protected IGardenTypeRepository GardenTypeRepository { get; private set; }

		public GardenTypeService(IGardenTypeRepository gardenTypeRepository)
		{
			GardenTypeRepository = gardenTypeRepository;
		}

		public IEnumerable<SelectListItem> GetGardenTypesSelectList()
		{
			return GardenTypeRepository.All().OrderBy(gtr => gtr.Ordinal).ToList().Select(gt => new SelectListItem() { Text = gt.Name, Value = gt.Id.ToString() });
		}
	}
}