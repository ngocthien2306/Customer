namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAttributeToMovieModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        MovieID = c.Byte(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.MovieID);
            
            AddColumn("dbo.Movies", "DayAdded", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "AmountOfRock", c => c.Byte(nullable: false));
            AddColumn("dbo.Movies", "Genres_MovieID", c => c.Byte());
            AlterColumn("dbo.Movies", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Movies", "Genre", c => c.Byte(nullable: false));
            AlterColumn("dbo.Movies", "Country", c => c.String(maxLength: 20));
            AlterColumn("dbo.Movies", "Releasedate", c => c.DateTimeOffset(precision: 7));
            CreateIndex("dbo.Movies", "Genres_MovieID");
            AddForeignKey("dbo.Movies", "Genres_MovieID", "dbo.Genres", "MovieID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "Genres_MovieID", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "Genres_MovieID" });
            AlterColumn("dbo.Movies", "Releasedate", c => c.DateTimeOffset(nullable: false, precision: 7));
            AlterColumn("dbo.Movies", "Country", c => c.String());
            AlterColumn("dbo.Movies", "Genre", c => c.String());
            AlterColumn("dbo.Movies", "Name", c => c.String());
            DropColumn("dbo.Movies", "Genres_MovieID");
            DropColumn("dbo.Movies", "AmountOfRock");
            DropColumn("dbo.Movies", "DayAdded");
            DropTable("dbo.Genres");
        }
    }
}
