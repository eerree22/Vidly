namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PutDataToGenre : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (MovieType) VALUES('超級英雄')");
            Sql("INSERT INTO Genres (MovieType) VALUES('劇情')");
            Sql("INSERT INTO Genres (MovieType) VALUES('懸疑')");
            Sql("INSERT INTO Genres (MovieType) VALUES('科幻')");
            Sql("INSERT INTO Genres (MovieType) VALUES('動畫')");

        }

        public override void Down()
        {
        }
    }
}
