using System.Collections.Generic;
using System.Linq;
using UtahsOwnGardenChallenge.Data.Entities;
using UtahsOwnGardenChallenge.Repositories;

namespace UtahsOwnGardenChallenge.Services
{

	public interface IPlantTypeService
	{
		IEnumerable<PlantType> GetAllPlantTypes();
	}
	public class PlantTypeService : IPlantTypeService
	{
		protected IPlantTypeRepository PlantTypeRepository { get; private set; }

		public PlantTypeService(IPlantTypeRepository plantTypeRepository)
		{
			PlantTypeRepository = plantTypeRepository;
		}

		public IEnumerable<PlantType> GetAllPlantTypes()
		{
			return PlantTypeRepository.All().OrderBy(ptr => ptr.Name);
		}
	}
}