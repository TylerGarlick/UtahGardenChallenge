namespace UtahsOwnGardenChallenge.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddZipCodeyToGarden : DbMigration
    {
        public override void Up()
        {
            AddColumn("Gardens", "ZipCode", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("Gardens", "ZipCode");
        }
    }
}
