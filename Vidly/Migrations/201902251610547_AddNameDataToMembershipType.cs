namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNameDataToMembershipType : DbMigration
    {
        public override void Up()
        {
            Sql("Update MembershipTypes Set Name='不限' Where Id=1");
            Sql("Update MembershipTypes Set Name='每月' Where Id=2");
            Sql("Update MembershipTypes Set Name='每季' Where Id=3");
            Sql("Update MembershipTypes Set Name='每年' Where Id=4");
        }
        
        public override void Down()
        {
        }
    }
}
