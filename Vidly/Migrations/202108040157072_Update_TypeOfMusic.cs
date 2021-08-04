namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_TypeOfMusic : DbMigration
    {
        public override void Up()
        {
            Sql("Update Genres SET Name = 'Action' WHERE MovieID = 1");
            Sql("Update Genres SET Name = 'Thriller' WHERE MovieID = 2");
            Sql("Update Genres SET Name = 'Romance' WHERE MovieID = 3");
            Sql("Update Genres SET Name = 'Family' WHERE MovieID = 4");
            Sql("Update Genres SET Name = 'Comedy' WHERE MovieID = 5");
        }
        
        public override void Down()
        {
        }
    }
}
