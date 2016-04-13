namespace CineticaApp.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CineticaApp.Models.CineticaAppContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CineticaApp.Models.CineticaAppContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
           context.Cineticas.AddOrUpdate(
                  c => c.Name,
                  new Models.Cinetica { UserId = new Guid().ToString(), Name = "MyApp", AccX = 345, AccY = 2134, AccZ = 2345, Time = DateTime.Now },
                  new Models.Cinetica { UserId = new Guid().ToString(), Name = "MyApp", AccX = 345, AccY = 2134, AccZ = 2345, Time = DateTime.Now },
                  new Models.Cinetica { UserId = new Guid().ToString(), Name = "MyApp", AccX = 345, AccY = 2134, AccZ = 2345, Time = DateTime.Now },
                  new Models.Cinetica { UserId = new Guid().ToString(), Name = "MyApp2", AccX = 345, AccY = 2134, AccZ = 2345, Time = DateTime.Now },
                  new Models.Cinetica { UserId = new Guid().ToString(), Name = "MyApp2", AccX = 345, AccY = 2134, AccZ = 2345, Time = DateTime.Now },
                  new Models.Cinetica { UserId = new Guid().ToString(), Name = "MyApp2", AccX = 345, AccY = 2134, AccZ = 2345, Time = DateTime.Now }
                );

        }
    }
}
