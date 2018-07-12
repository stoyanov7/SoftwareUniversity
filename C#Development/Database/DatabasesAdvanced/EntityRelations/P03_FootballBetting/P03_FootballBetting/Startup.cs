namespace P03_FootballBetting
{
    using Data;
    using Microsoft.EntityFrameworkCore;

    public class Startup
    {
        public static void Main(string[] args)
        {
            using (var context = new FootballBettingContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                context.Database.Migrate();
            }
        }
    }
}
