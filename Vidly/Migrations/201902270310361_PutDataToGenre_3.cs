namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PutDataToGenre_3 : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (MovieType) VALUES(N'超級英雄')");
            Sql("INSERT INTO Genres (MovieType) VALUES(N'劇情')");
            Sql("INSERT INTO Genres (MovieType) VALUES(N'懸疑')");
            Sql("INSERT INTO Genres (MovieType) VALUES(N'科幻')");
            Sql("INSERT INTO Genres (MovieType) VALUES(N'動畫')");
        }
        
        public override void Down()
        {
        }
    }
}
