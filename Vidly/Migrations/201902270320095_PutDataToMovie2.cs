namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PutDataToMovie2 : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Movies (Name,ReleaseDate,DateAdded,NumberInStock,GenreId) VALUES(N'�����Ұ�',CAST('2007/6/17' as DATETIME),GETDATE(),63,12)");
            Sql("INSERT INTO Movies (Name,ReleaseDate,DateAdded,NumberInStock,GenreId) VALUES(N'�O�Ы���',CAST('1999/1/13' as DATETIME),GETDATE(),36,13)");
            Sql("INSERT INTO Movies (Name,ReleaseDate,DateAdded,NumberInStock,GenreId) VALUES(N'�P�ڮ���',CAST('2012/2/1' as DATETIME),GETDATE(),89,14)");
            Sql("INSERT INTO Movies (Name,ReleaseDate,DateAdded,NumberInStock,GenreId) VALUES(N'���y��M',CAST('2001/9/12' as DATETIME),GETDATE(),123,15)");

        }

        public override void Down()
        {
        }
    }
}
