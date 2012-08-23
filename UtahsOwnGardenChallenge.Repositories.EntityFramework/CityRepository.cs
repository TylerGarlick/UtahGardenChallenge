using System.Data.Entity;
using NexBusiness.Repositories;
using UtahsOwnGardenChallenge.Data;
using UtahsOwnGardenChallenge.Data.Entities;

namespace UtahsOwnGardenChallenge.Repositories.EntityFramework
{
	public class CityRepository : Repository<City, DatabaseDbContext>, ICityRepository
	{
		public CityRepository(DbContext dbContext)
			: base(dbContext)
		{ }
	}
}