// <auto-generated />
namespace UtahsOwnGardenChallenge.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Migrations.Infrastructure;
    
    public sealed partial class AddCityAndCountyNames : IMigrationMetadata
    {
        string IMigrationMetadata.Id
        {
            get { return "201206142115320_AddCityAndCountyNames"; }
        }
        
        string IMigrationMetadata.Source
        {
            get { return null; }
        }
        
        string IMigrationMetadata.Target
        {
            get { return "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"; }
        }
    }
}
