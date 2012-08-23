namespace UtahsOwnGardenChallenge.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddLongitudeAndLatitudeOnCity : DbMigration
    {
        public override void Up()
        {
            AddColumn("Cities", "Longitude", c => c.Single());
            AddColumn("Cities", "Latitude", c => c.Single());
        }
        
        public override void Down()
        {
            DropColumn("Cities", "Latitude");
            DropColumn("Cities", "Longitude");
        }
    }
}
