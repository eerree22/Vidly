namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PutDataToGenre_3 : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (MovieType) VALUES(N'�W�ŭ^��')");
            Sql("INSERT INTO Genres (MovieType) VALUES(N'�@��')");
            Sql("INSERT INTO Genres (MovieType) VALUES(N'�a��')");
            Sql("INSERT INTO Genres (MovieType) VALUES(N'���')");
            Sql("INSERT INTO Genres (MovieType) VALUES(N'�ʵe')");
        }
        
        public override void Down()
        {
        }
    }
}
