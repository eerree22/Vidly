namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterGenre : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Genres", "MovieType", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Genres", "MovieType", c => c.Int(nullable: false));
        }
    }
}
