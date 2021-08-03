namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNameTypeAlbumsMusic : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO TypeOfAlbums (Id, Name) VALUES (1, 'Rock')");
            Sql("INSERT INTO TypeOfAlbums (Id, Name) VALUES (2, 'Pop Music')");
            Sql("INSERT INTO TypeOfAlbums (Id, Name) VALUES (3, 'Classical Music')");
            Sql("INSERT INTO TypeOfAlbums (Id, Name) VALUES (4, 'Popular Music')");
            Sql("INSERT INTO TypeOfAlbums (Id, Name) VALUES (5, 'Blues')");
            Sql("INSERT INTO TypeOfAlbums (Id, Name) VALUES (6, 'Ballad')");
            Sql("INSERT INTO TypeOfAlbums (Id, Name) VALUES (7, 'Rock and Roll')");
            Sql("INSERT INTO TypeOfAlbums (Id, Name) VALUES (8, 'K-Pop')");
            Sql("INSERT INTO TypeOfAlbums (Id, Name) VALUES (9, 'Other')");
        }
        
        public override void Down()
        {
        }
    }
}
