using System.Data.Entity;
using NexBusiness.Repositories;
using UtahsOwnGardenChallenge.Data;
using UtahsOwnGardenChallenge.Data.Entities;

namespace UtahsOwnGardenChallenge.Repositories.EntityFramework
{
	public class GardenTypeRepository : Repository<GardenType, DatabaseDbContext>, IGardenTypeRepository
	{
		public GardenTypeRepository(DbContext dbContext)
			: base(dbContext)
		{ }
	}
}