namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNameDataToMembershipType : DbMigration
    {
        public override void Up()
        {
            Sql("Update MembershipTypes Set Name='����' Where Id=1");
            Sql("Update MembershipTypes Set Name='�C��' Where Id=2");
            Sql("Update MembershipTypes Set Name='�C�u' Where Id=3");
            Sql("Update MembershipTypes Set Name='�C�~' Where Id=4");
        }
        
        public override void Down()
        {
        }
    }
}
