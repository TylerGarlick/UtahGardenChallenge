using System.Collections.Generic;
using UtahsOwnGardenChallenge.Data.Entities;
using UtahsOwnGardenChallenge.Repositories;

namespace UtahsOwnGardenChallenge.Services
{
	public interface IGardenReasonService
	{
		IEnumerable<GardenReason> GetAllGardenReasons();
	}

	public class GardenReasonService : IGardenReasonService
	{
		protected IGardenReasonRepository GardenReasonRepository { get; private set; }

		public GardenReasonService(IGardenReasonRepository gardenReasonRepository)
		{
			GardenReasonRepository = gardenReasonRepository;
		}


		public IEnumerable<GardenReason> GetAllGardenReasons()
		{
			return GardenReasonRepository.All();
		}
	}

	
}