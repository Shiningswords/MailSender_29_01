using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirstTest.Data.Entities;
//using CodeFirstTest.Migrations;

namespace CodeFirstTest.Data
{
    public class TestSongsDBContext : DbContext
    {
        //static TestSongsDBContext() => System.Data.Entity.Database.SetInitializer(new DropCreateDatabaseAlways<TestSongsDBContext>());
        //static TestSongsDBContext() => System.Data.Entity.Database.SetInitializer(new CreateDatabaseIfNotExists<TestSongsDBContext>());
        //static TestSongsDBContext() => System.Data.Entity.Database.SetInitializer(new DropCreateDatabaseIfModelChanges<TestSongsDBContext>());
        //static TestSongsDBContext() => Database.SetInitializer(new MigrateDatabaseToLatestVersion<TestSongsDBContext, Configuration>());


        public DbSet<Artist> Artists { get; set; }

        public DbSet<Song> Songs { get; set; }

        public DbSet<Distributors> Distributors { get; set; }


        public TestSongsDBContext() : this("name=DefaultConnection") { }

        public TestSongsDBContext(string ConnectionString) : base(ConnectionString) { }
    }
}
