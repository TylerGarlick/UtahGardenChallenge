namespace UtahsOwnGardenChallenge.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddCityAndCountyNames : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("Gardens", "City_Id", "Cities");
            DropForeignKey("Gardens", "County_Id", "Counties");
            DropIndex("Gardens", new[] { "City_Id" });
            DropIndex("Gardens", new[] { "County_Id" });
            AddColumn("Gardens", "CityName", c => c.String(nullable: false));
            AddColumn("Gardens", "CountyName", c => c.String(nullable: false));
            AlterColumn("Gardens", "City_Id", c => c.Guid(nullable:true));
			AlterColumn("Gardens", "County_Id", c => c.Guid(nullable: true));
            AddForeignKey("Gardens", "City_Id", "Cities", "Id");
            AddForeignKey("Gardens", "County_Id", "Counties", "Id");
            CreateIndex("Gardens", "City_Id");
            CreateIndex("Gardens", "County_Id");
        }
        
        public override void Down()
        {
            DropIndex("Gardens", new[] { "County_Id" });
            DropIndex("Gardens", new[] { "City_Id" });
            DropForeignKey("Gardens", "County_Id", "Counties");
            DropForeignKey("Gardens", "City_Id", "Cities");
            AlterColumn("Gardens", "County_Id", c => c.Guid(nullable: false));
            AlterColumn("Gardens", "City_Id", c => c.Guid(nullable: false));
            DropColumn("Gardens", "CountyName");
            DropColumn("Gardens", "CityName");
            CreateIndex("Gardens", "County_Id");
            CreateIndex("Gardens", "City_Id");
            AddForeignKey("Gardens", "County_Id", "Counties", "Id", cascadeDelete: true);
            AddForeignKey("Gardens", "City_Id", "Cities", "Id", cascadeDelete: true);
        }
    }
}
