using System.Data.Entity;
using UtahsOwnGardenChallenge.Data.Entities;

namespace UtahsOwnGardenChallenge.Data
{
	public class DatabaseDbContext : DbContext
	{
		public DbSet<City> Cities { get; set; }
		public DbSet<County> Counties { get; set; }
		public DbSet<Garden> Gardens { get; set; }
		public DbSet<GardenReason> GardenReasons { get; set; }
		public DbSet<GardenSize> GardenSizes { get; set; }
		public DbSet<GardenType> GardenTypes { get; set; }
		public DbSet<PlantType> PlantTypes { get; set; }
	}
}
