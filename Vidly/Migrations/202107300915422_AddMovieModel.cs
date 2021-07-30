namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMovieModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "Genres_MovieID", c => c.Byte(nullable: false));
            AddColumn("dbo.Movies", "Genres_Name", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Movies", "DayAdded", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "AmountOfRock", c => c.Byte(nullable: false));
            AlterColumn("dbo.Movies", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Movies", "Genre", c => c.Byte(nullable: false));
            AlterColumn("dbo.Movies", "Country", c => c.String(maxLength: 20));
            AlterColumn("dbo.Movies", "Releasedate", c => c.DateTimeOffset(precision: 7));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "Releasedate", c => c.DateTimeOffset(nullable: false, precision: 7));
            AlterColumn("dbo.Movies", "Country", c => c.String());
            AlterColumn("dbo.Movies", "Genre", c => c.String());
            AlterColumn("dbo.Movies", "Name", c => c.String());
            DropColumn("dbo.Movies", "AmountOfRock");
            DropColumn("dbo.Movies", "DayAdded");
            DropColumn("dbo.Movies", "Genres_Name");
            DropColumn("dbo.Movies", "Genres_MovieID");
        }
    }
}
