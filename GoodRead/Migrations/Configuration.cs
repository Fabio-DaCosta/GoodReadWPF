namespace GoodRead.Migrations
{
    using GoodRead.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GoodRead.Models.GoodReadsDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(GoodRead.Models.GoodReadsDB context)
        {
            User user = new User
            {
                Username = "RoyBoy",
                Password = "1234",
            };

            context.Users.AddOrUpdate(n => n.Username,
                user);

            context.SaveChanges();

            Category romance = new Category
            {
                CategoryName = "Romance"
            };

            Category drama = new Category
            {
                CategoryName = "Drama"
            };

            context.Categories.AddOrUpdate(c => c.CategoryName,
                romance,
                drama);

            context.SaveChanges();

            Book book = new Book
            {
                Name = "The Beginning After The End Volume 1",
                Author = "TurtleMe83"
            };
            Book tog = new Book
            {
                Name = "Throne of Glass",
                Author = "Sarah J. Maas"
            };

            book.Categories.Add(romance);
            book.Categories.Add(drama);

            tog.Categories.Add(romance);
            tog.Categories.Add(drama);

            context.Books.AddOrUpdate(b => b.Name,
                book,
                tog);

            context.SaveChanges();
        }
    }
}
