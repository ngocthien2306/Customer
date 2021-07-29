namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Re_UpdatePopulateMembershipType : DbMigration
    {
        public override void Up()
        {
            Sql("Update MemberShipTypes SET NameOfMemberShip = 'Pay as You Go' WHERE Id = 1");
            Sql("Update MemberShipTypes SET NameOfMemberShip = 'Monthly' WHERE SignUpFee = 2");
            Sql("Update MemberShipTypes SET NameOfMemberShip = 'Quaterly' WHERE SignUpFee = 3");
            Sql("Update MemberShipTypes SET NameOfMemberShip = 'Annual' WHERE SignUpFee = 4");
        }
        
        public override void Down()
        {

        }
    }
}
