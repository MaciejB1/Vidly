namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGenres : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (id, Name) VALUES (1, 'Comedy')");
            Sql("INSERT INTO Genres (id, Name) VALUES (2, 'Horror movie')");
            Sql("INSERT INTO Genres (id, Name) VALUES (3, 'Documentary')");
            Sql("INSERT INTO Genres (id, Name) VALUES (4, 'Science Fiction')");
            Sql("INSERT INTO Genres (id, Name) VALUES (5, 'Action movie')");
            Sql("INSERT INTO Genres (id, Name) VALUES (6, 'Children film')");
        }
        
        public override void Down()
        {
        }
    }
}
