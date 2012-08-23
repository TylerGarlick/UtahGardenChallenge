namespace UtahsOwnGardenChallenge.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddCanBeContactedByNass : DbMigration
    {
        public override void Up()
        {
            AddColumn("Gardens", "CanBeContactedByNas", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("Gardens", "CanBeContactedByNas");
        }
    }
}
