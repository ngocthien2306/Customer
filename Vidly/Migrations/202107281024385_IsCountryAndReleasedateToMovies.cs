namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsCountryAndReleasedateToMovies : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "Country", c => c.String());
            AddColumn("dbo.Movies", "Releasedate", c => c.DateTimeOffset(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "Releasedate");
            DropColumn("dbo.Movies", "Country");
        }
    }
}
