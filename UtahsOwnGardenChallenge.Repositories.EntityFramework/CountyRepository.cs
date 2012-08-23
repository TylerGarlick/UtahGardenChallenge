using System.Data.Entity;
using NexBusiness.Repositories;
using UtahsOwnGardenChallenge.Data;
using UtahsOwnGardenChallenge.Data.Entities;

namespace UtahsOwnGardenChallenge.Repositories.EntityFramework
{
	public class CountyRepository : Repository<County, DatabaseDbContext>, ICountyRepository
	{
		public CountyRepository(DbContext dbContext)
			: base(dbContext)
		{ }
	}
}