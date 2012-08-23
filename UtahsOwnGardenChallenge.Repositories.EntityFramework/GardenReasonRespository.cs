using System.Data.Entity;
using NexBusiness.Repositories;
using UtahsOwnGardenChallenge.Data;
using UtahsOwnGardenChallenge.Data.Entities;

namespace UtahsOwnGardenChallenge.Repositories.EntityFramework
{
	public class GardenReasonRespository : Repository<GardenReason, DatabaseDbContext>, IGardenReasonRepository
	{
		public GardenReasonRespository(DbContext dbContext)
			: base(dbContext)
		{ }
	}
}