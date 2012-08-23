namespace UtahsOwnGardenChallenge.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddCountyToGarden : DbMigration
    {
        public override void Up()
        {
            AddColumn("Gardens", "County_Id", c => c.Guid(nullable: false));
            AddForeignKey("Gardens", "County_Id", "Counties", "Id");
            CreateIndex("Gardens", "County_Id");
        }
        
        public override void Down()
        {
            DropIndex("Gardens", new[] { "County_Id" });
            DropForeignKey("Gardens", "County_Id", "Counties");
            DropColumn("Gardens", "County_Id");
        }
    }
}
