namespace FarmTradeFinal.Migrations
{
    using FarmTradeFinal.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FarmTradeFinal.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(FarmTradeFinal.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            var locations = new List<Location>
            {
                new Location { City = "Athens", PostalCode ="12345"},
                new Location { City ="Korinthos", PostalCode ="54321"}
            };
            locations.ForEach(l => context.Locations.AddOrUpdate(i => i.PostalCode, l));
            context.SaveChanges();


            var qualities = new List<Quality>
            {
                new Quality { Name = "A"},
                new Quality { Name = "B"},
                new Quality { Name = "C"},
                new Quality { Name = "D"},
                new Quality { Name = "E"},
                new Quality { Name = "F"},
            };
            qualities.ForEach(q => context.Qualities.AddOrUpdate(i => i.Name, q));
            context.SaveChanges();

            var categories = new List<Category>
           {
               new Category { Name = "Grains"},
               new Category {Name = "Rise"}
           };

            categories.ForEach(c => context.Categories.AddOrUpdate(p => p.Name, c));
            context.SaveChanges();

            var products = new List<Product>
            {
                new Product { Name = "Soft Wheat", CategoryID = categories.Single( i => i.Name =="Grains").ID},
                new Product { Name = "Hard Wheat", CategoryID = categories.Single( i => i.Name =="Grains").ID},
                new Product { Name = "Oat", CategoryID = categories.Single( i => i.Name =="Grains").ID},
                new Product { Name = "Corn", CategoryID = categories.Single( i => i.Name =="Grains").ID},
                new Product { Name = "Barley", CategoryID = categories.Single( i => i.Name =="Grains").ID},
                new Product { Name = "Sorghum", CategoryID = categories.Single( i => i.Name =="Grains").ID},
                new Product { Name = "Millet", CategoryID = categories.Single( i => i.Name =="Grains").ID},
                new Product { Name = "Triticale", CategoryID = categories.Single( i => i.Name =="Grains").ID},
                new Product { Name = "Low GI White", CategoryID = categories.Single( i => i.Name =="Rise").ID},
                new Product { Name = "Basmati", CategoryID = categories.Single( i => i.Name =="Rise").ID},
                new Product { Name = "Jasmine", CategoryID = categories.Single( i => i.Name =="Rise").ID},
                new Product { Name = "Arborio", CategoryID = categories.Single( i => i.Name =="Rise").ID},
                new Product { Name = "Brown", CategoryID = categories.Single( i => i.Name =="Rise").ID},
                new Product { Name = "Coloured", CategoryID = categories.Single( i => i.Name =="Rise").ID},

                new Product { Name = "Low GI White", CategoryID = categories.Single( i => i.Name =="Rise").ID},
            };
            products.ForEach(p => context.Products.AddOrUpdate(i => i.Name, p));
            context.SaveChanges();







        }
    }
}
