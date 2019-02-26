namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PutBirthdateDataToCustomer : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customers SET Birthdate = CAST('1987/8/7' as DATETIME) WHERE Id = 1");
            Sql("UPDATE Customers SET Birthdate = CAST('1995/6/6' as DATETIME) WHERE Id = 3");
        }

        public override void Down()
        {
        }
    }
}
