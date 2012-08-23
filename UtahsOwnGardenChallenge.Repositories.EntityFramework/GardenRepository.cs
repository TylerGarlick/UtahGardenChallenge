using System.Data.Entity;
using NexBusiness.Repositories;
using UtahsOwnGardenChallenge.Data;
using UtahsOwnGardenChallenge.Data.Entities;

namespace UtahsOwnGardenChallenge.Repositories.EntityFramework
{
	public class GardenRepository : Repository<Garden, DatabaseDbContext>, IGardenRepository
	{
		public GardenRepository(DbContext dbContext)
			: base(dbContext)
		{ }

	}
}
