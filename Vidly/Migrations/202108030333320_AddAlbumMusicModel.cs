namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAlbumMusicModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AlbumMusics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 255),
                        Type = c.Byte(nullable: false),
                        Country = c.String(nullable: false, maxLength: 30),
                        ReleaseDate = c.DateTime(),
                        AmountOfAlbum = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AlterColumn("dbo.Movies", "Genre", c => c.Byte(nullable: false));
            AlterColumn("dbo.Movies", "Country", c => c.String(nullable: false, maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "Country", c => c.String(maxLength: 20));
            AlterColumn("dbo.Movies", "Genre", c => c.String(nullable: false));
            DropTable("dbo.AlbumMusics");
        }
    }
}
