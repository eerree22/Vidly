namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PutDataToGenre : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (MovieType) VALUES('�W�ŭ^��')");
            Sql("INSERT INTO Genres (MovieType) VALUES('�@��')");
            Sql("INSERT INTO Genres (MovieType) VALUES('�a��')");
            Sql("INSERT INTO Genres (MovieType) VALUES('���')");
            Sql("INSERT INTO Genres (MovieType) VALUES('�ʵe')");

        }

        public override void Down()
        {
        }
    }
}
