using System.Data.Entity;
using NexBusiness.Repositories;
using UtahsOwnGardenChallenge.Data;
using UtahsOwnGardenChallenge.Data.Entities;

namespace UtahsOwnGardenChallenge.Repositories.EntityFramework
{
	public class PlantTypeRepository : Repository<PlantType, DatabaseDbContext>, IPlantTypeRepository
	{
		public PlantTypeRepository(DbContext dbContext)
			: base(dbContext)
		{ }
	}
}