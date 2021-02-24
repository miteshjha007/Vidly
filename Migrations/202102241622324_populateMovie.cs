namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateMovie : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into Movies (Name,ReleaseDate,DateAdded,NumberInStock,GenreId) values('Movie1','2000-07-10','2000-07-12',5,5)");
            Sql("Insert into Movies (Name,ReleaseDate,DateAdded,NumberInStock,GenreId) values('Movie2','2000-07-10','2000-07-12',5,5)");
            Sql("Insert into Movies (Name,ReleaseDate,DateAdded,NumberInStock,GenreId) values('Movie3','2000-07-10','2000-07-12',5,5)");
            Sql("Insert into Movies (Name,ReleaseDate,DateAdded,NumberInStock,GenreId) values('Movie4','2000-07-10','2000-07-12',5,5)");
            Sql("Insert into Movies (Name,ReleaseDate,DateAdded,NumberInStock,GenreId) values('Movie5','2000-07-10','2000-07-12',5,5)");
        }
        
        public override void Down()
        {
        }
    }
}
