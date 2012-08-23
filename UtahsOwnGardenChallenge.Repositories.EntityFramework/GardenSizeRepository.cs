using System.Data.Entity;
using NexBusiness.Repositories;
using UtahsOwnGardenChallenge.Data;
using UtahsOwnGardenChallenge.Data.Entities;

namespace UtahsOwnGardenChallenge.Repositories.EntityFramework
{
	public class GardenSizeRepository : Repository<GardenSize, DatabaseDbContext>, IGardenSizeRepository
	{
		public GardenSizeRepository(DbContext dbContext)
			: base(dbContext)
		{ }
	}
}