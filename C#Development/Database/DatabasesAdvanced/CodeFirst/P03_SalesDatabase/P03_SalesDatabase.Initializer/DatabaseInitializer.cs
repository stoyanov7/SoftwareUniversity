namespace P03_SalesDatabase.Initializer
{
    using System;
    using Data;
    using Generators;
    using Microsoft.EntityFrameworkCore;

    public class DatabaseInitializer
    {
        public static void ResetDatabase()
        {
            using (var context = new SalesContext())
            {
                context.Database.EnsureDeleted();
                context.Database.Migrate();

                InitialSeed(context);
            }
        }

        public static void InitialSeed(SalesContext context)
        {
            SeedCustomers(context, 100);
        }

        private static void SeedCustomers(SalesContext context, int count)
        {
            for (var i = 0; i < count; i++)
            {
                context.Customers.Add(CustomerGenerator.NewCustomer(context));
            }

            context.SaveChanges();
        }
    }
}
