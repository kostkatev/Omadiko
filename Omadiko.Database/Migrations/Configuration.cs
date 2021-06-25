namespace Omadiko.Database.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Omadiko.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Omadiko.Database.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Omadiko.Database.ApplicationDbContext context)
        {
            Product p1 = new Product() { Name = "TurboX", Price = 550 };
            Product p2 = new Product() { Name = "HP", Price = 200 };
            Product p3 = new Product() { Name = "Samsung", Price = 300 };
            Product p4 = new Product() { Name = "Apple", Price = 900 };
            Product p5 = new Product() { Name = "HP", Price = 800 };
            Product p6 = new Product() { Name = "LG", Price = 900 };


            Customer c1 = new Customer() { FirstName = "Hector", LastName = "Gkatsos" };
            c1.Products = new List<Product>() { p1, p2, p3 };
            Customer c2 = new Customer() { FirstName = "Kostas", LastName = "Katevas" };
            Customer c3 = new Customer() { FirstName = "Thodoris", LastName = "Papamokos" };
            c3.Products = new List<Product>() { p1 };
            Customer c4 = new Customer() { FirstName = "Elina", LastName = "Zafeiri" };
            c4.Products = new List<Product>() { p1, p2 };
            Customer c5 = new Customer() { FirstName = "Maria", LastName = "Pappa" };
            c5.Products = new List<Product>() { p4, p2, p3 };
            Customer c6 = new Customer() { FirstName = "George", LastName = "Pappas" };
            c6.Products = new List<Product>() { p5, p6, p3 };
            Customer c7 = new Customer() { FirstName = "Kostas", LastName = "Markou" };
            c7.Products = new List<Product>() { p6, p4, p3 };
            Customer c8 = new Customer() { FirstName = "Eleni", LastName = "Pappa" };
            c8.Products = new List<Product>() { p4, p1, p3 };

            context.Products.AddOrUpdate(x => new { x.Name }, p1, p2, p3, p4, p5, p6);
            context.Customers.AddOrUpdate(x => new { x.FirstName, x.LastName }, c1, c2, c3, c4, c5, c6, c7, c8);
            

            context.SaveChanges();

            if (!context.Roles.Any(x => x.Name == "Admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Admin" };

                manager.Create(role);
            }

            var PasswordHash = new PasswordHasher();
            if (!context.Users.Any(x => x.UserName == "admin@admin.net"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser
                {
                    UserName = "admin@admin.net",
                    Email = "admin@admin.net",
                    PasswordHash = PasswordHash.HashPassword("Admin1!")
                };

                manager.Create(user);
                manager.AddToRole(user.Id, "Admin");
            }
        }
    }
}
