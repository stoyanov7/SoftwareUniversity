namespace FDMC.Data
{
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class FdmcContext : DbContext
    {
        public FdmcContext()
        {
        }

        public FdmcContext(DbContextOptions options) 
            : base(options)
        {
        }

        public DbSet<Cat> Cats { get; set; }
    }
}
