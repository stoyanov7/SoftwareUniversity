namespace BookShop.Initializer
{
    using System;
    using Data;
    using Generators;

    public static class DbInitializer
    {
        public static void ResetDatabase()
        {
            using (var context = new BookShopContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Console.WriteLine("BookShop database created successfully.");

                Seed(context);
            }
        }

        private static void Seed(BookShopContext context)
        {
            var books = BookGenerator.CreateBooks();

            context.Books.AddRange(books);
            context.SaveChanges();

            Console.WriteLine("Sample data inserted successfully.");
        }
    }
}
