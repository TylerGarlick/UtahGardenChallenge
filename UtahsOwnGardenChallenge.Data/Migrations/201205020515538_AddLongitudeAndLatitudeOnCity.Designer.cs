// <auto-generated />
namespace UtahsOwnGardenChallenge.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Migrations.Infrastructure;
    
    public sealed partial class AddLongitudeAndLatitudeOnCity : IMigrationMetadata
    {
        string IMigrationMetadata.Id
        {
            get { return "201205020515538_AddLongitudeAndLatitudeOnCity"; }
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