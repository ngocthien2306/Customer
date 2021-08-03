namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTyperOfAlbumModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TypeOfAlbums",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AlbumMusics", "TypeOfAlbum_Id", c => c.Int());
            CreateIndex("dbo.AlbumMusics", "TypeOfAlbum_Id");
            AddForeignKey("dbo.AlbumMusics", "TypeOfAlbum_Id", "dbo.TypeOfAlbums", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AlbumMusics", "TypeOfAlbum_Id", "dbo.TypeOfAlbums");
            DropIndex("dbo.AlbumMusics", new[] { "TypeOfAlbum_Id" });
            DropColumn("dbo.AlbumMusics", "TypeOfAlbum_Id");
            DropTable("dbo.TypeOfAlbums");
        }
    }
}
