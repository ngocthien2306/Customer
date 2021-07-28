namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipType : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MemberShipTypes (Id, SignUpFee, DurationInMonths, DiscountRate, NameOfMemberShip) VALUES" +
                "(1, 0, 0, 0, 1)");
            Sql("INSERT INTO MemberShipTypes (Id, SignUpFee, DurationInMonths, DiscountRate, NameOfMemberShip) VALUES" +
                "(2, 30, 1, 10, 1)");
            Sql("INSERT INTO MemberShipTypes (Id, SignUpFee, DurationInMonths, DiscountRate, NameOfMemberShip) VALUES" +
                "(3, 90, 3, 15, 2)");
            Sql("INSERT INTO MemberShipTypes (Id, SignUpFee, DurationInMonths, DiscountRate, NameOfMemberShip) VALUES" +
                "(4, 300, 12, 20, 3)");
        }
        
        public override void Down()
        {
        }
    }
}
