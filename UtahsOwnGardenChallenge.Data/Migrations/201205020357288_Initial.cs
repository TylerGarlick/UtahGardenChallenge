namespace UtahsOwnGardenChallenge.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Cities",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        UpdatedOn = c.DateTime(),
                        County_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Counties", t => t.County_Id)
                .Index(t => t.County_Id);
            
            CreateTable(
                "Counties",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        UpdatedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Gardens",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 150),
                        LastName = c.String(nullable: false, maxLength: 150),
                        GardenName = c.String(maxLength: 150),
                        GroupName = c.String(maxLength: 150),
                        Email = c.String(nullable: false, maxLength: 512),
                        Address = c.String(nullable: false, maxLength: 150),
                        CreatedOn = c.DateTime(nullable: false),
                        UpdatedOn = c.DateTime(),
                        City_Id = c.Guid(nullable: false),
                        GardenSize_Id = c.Guid(nullable: false),
                        GardenType_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Cities", t => t.City_Id)
                .ForeignKey("GardenSizes", t => t.GardenSize_Id)
                .ForeignKey("GardenTypes", t => t.GardenType_Id)
                .Index(t => t.City_Id)
                .Index(t => t.GardenSize_Id)
                .Index(t => t.GardenType_Id);
            
            CreateTable(
                "GardenSizes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        UpdatedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "GardenTypes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        UpdatedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "GardenReasons",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 150),
                        CreatedOn = c.DateTime(nullable: false),
                        UpdatedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "PlantTypes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        UpdatedOn = c.DateTime(),
                        Garden_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Gardens", t => t.Garden_Id)
                .Index(t => t.Garden_Id);
            
            CreateTable(
                "GardenReasonGardens",
                c => new
                    {
                        GardenReason_Id = c.Guid(nullable: false),
                        Garden_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.GardenReason_Id, t.Garden_Id })
                .ForeignKey("GardenReasons", t => t.GardenReason_Id)
                .ForeignKey("Gardens", t => t.Garden_Id)
                .Index(t => t.GardenReason_Id)
                .Index(t => t.Garden_Id);
            
        }
        
        public override void Down()
        {
            DropIndex("GardenReasonGardens", new[] { "Garden_Id" });
            DropIndex("GardenReasonGardens", new[] { "GardenReason_Id" });
            DropIndex("PlantTypes", new[] { "Garden_Id" });
            DropIndex("Gardens", new[] { "GardenType_Id" });
            DropIndex("Gardens", new[] { "GardenSize_Id" });
            DropIndex("Gardens", new[] { "City_Id" });
            DropIndex("Cities", new[] { "County_Id" });
            DropForeignKey("GardenReasonGardens", "Garden_Id", "Gardens");
            DropForeignKey("GardenReasonGardens", "GardenReason_Id", "GardenReasons");
            DropForeignKey("PlantTypes", "Garden_Id", "Gardens");
            DropForeignKey("Gardens", "GardenType_Id", "GardenTypes");
            DropForeignKey("Gardens", "GardenSize_Id", "GardenSizes");
            DropForeignKey("Gardens", "City_Id", "Cities");
            DropForeignKey("Cities", "County_Id", "Counties");
            DropTable("GardenReasonGardens");
            DropTable("PlantTypes");
            DropTable("GardenReasons");
            DropTable("GardenTypes");
            DropTable("GardenSizes");
            DropTable("Gardens");
            DropTable("Counties");
            DropTable("Cities");
        }
    }
}
