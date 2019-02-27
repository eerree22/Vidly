namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteDataInGenre : DbMigration
    {
        public override void Up()
        {
            Sql("DELETE FROM Genres");
        }
        
        public override void Down()
        {
        }
    }
}
