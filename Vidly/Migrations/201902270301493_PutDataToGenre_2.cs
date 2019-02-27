namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PutDataToGenre_2 : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (MovieType) VALUES('GGGG')");
            Sql("INSERT INTO Genres (MovieType) VALUES('YYY')");
            Sql("INSERT INTO Genres (MovieType) VALUES('CCC')");
            Sql("INSERT INTO Genres (MovieType) VALUES('DDD')");
            Sql("INSERT INTO Genres (MovieType) VALUES('XXX')");
        }
        
        public override void Down()
        {
        }
    }
}
