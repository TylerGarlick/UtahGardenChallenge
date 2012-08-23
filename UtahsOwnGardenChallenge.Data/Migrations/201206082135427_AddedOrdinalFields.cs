namespace UtahsOwnGardenChallenge.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddedOrdinalFields : DbMigration
    {
        public override void Up()
        {
            AddColumn("GardenSizes", "Ordinal", c => c.Int(nullable: false));
            AddColumn("GardenTypes", "Ordinal", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("GardenTypes", "Ordinal");
            DropColumn("GardenSizes", "Ordinal");
        }
    }
}
