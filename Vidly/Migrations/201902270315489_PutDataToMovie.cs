namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PutDataToMovie : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Movies (Name,ReleaseDate,DateAdded,NumberInStock,GenreId) VALUES(N'¶Â·tÃM¤h',CAST('1987/8/7' as DATETIME),GETDATE(),46,11)");
        }
        
        public override void Down()
        {
        }
    }
}
