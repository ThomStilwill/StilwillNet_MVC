using System;
using System.Data.Entity.Migrations;
using Stilwill.Web.Areas.Auto.Models;
using Stilwill.Web.Models;

namespace Stilwill.Web.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Stilwill.Web.Models.ApplicationDbContext";
        }

        protected override void Seed(ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //



            context.Vehicles.Add(new Vehicle
            {
                Id = 1,
                Name = "Gunther",
                Make = "VW",
                Model = "GTI",
                Year = "2007",
                PurchaseDate = DateTime.Parse("2/20/2007")
            });
        }
    }
}
