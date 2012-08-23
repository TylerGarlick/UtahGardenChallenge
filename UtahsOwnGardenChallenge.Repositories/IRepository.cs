using Ninject;
namespace UtahsOwnGardenChallenge.Repositories
{
	public interface IRepository
	{
		ICityRepository Cities { get; set; }
		ICountyRepository Counties { get; set; }
		IGardenRepository Gardens { get; set; }
		IGardenReasonRepository GardenReasons { get; set; }
		IGardenSizeRepository GardenSizes { get; set; }
		IGardenTypeRepository GardenTypes { get; set; }
		IPlantTypeRepository PlantTypes { get; set; }
	}

	public class Repository : IRepository
	{
		[Inject]
		public ICityRepository Cities { get; set; }

		[Inject]
		public ICountyRepository Counties { get; set; }

		[Inject]
		public IGardenRepository Gardens { get; set; }

		[Inject]
		public IGardenReasonRepository GardenReasons { get; set; }

		[Inject]
		public IGardenSizeRepository GardenSizes { get; set; }

		[Inject]
		public IGardenTypeRepository GardenTypes { get; set; }

		[Inject]
		public IPlantTypeRepository PlantTypes { get; set; }
	}
}
