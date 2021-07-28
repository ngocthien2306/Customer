namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatePopulateMembershipType : DbMigration
    {
        public override void Up()
        {
            Sql("Update MemberShipTypes SET NameOfMemberShip = 'Pay as You Go' WHERE SignUpFee = 0");
            Sql("Update MemberShipTypes SET NameOfMemberShip = 'Monthly' WHERE SignUpFee = 30");
            Sql("Update MemberShipTypes SET NameOfMemberShip = 'Quaterly' WHERE SignUpFee = 90");
            Sql("Update MemberShipTypes SET NameOfMemberShip = 'Annual' WHERE SignUpFee = 300");
        }
        
        public override void Down()
        {
        }
    }
}
