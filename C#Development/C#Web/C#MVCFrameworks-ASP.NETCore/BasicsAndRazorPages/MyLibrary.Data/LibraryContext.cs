namespace MyLibrary.Data
{
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class LibraryContext : DbContext
    {
        public LibraryContext()
        {
        }

        public LibraryContext(DbContextOptions options) 
            : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<BookBorrowers> BookBorrowers { get; set; }

        public DbSet<Borrower> Borrowers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasOne(x => x.Author)
                .WithMany(x => x.Books)
                .HasForeignKey(x => x.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<BookBorrowers>()
                .HasOne(e => e.Book)
                .WithMany(b => b.Borrowerses)
                .HasForeignKey(b => b.BookId)
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<BookBorrowers>()
                .HasOne(e => e.Borrower)
                .WithMany(b => b.BorrowersedBooks)
                .HasForeignKey(b => b.BorrowerId)
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<BookBorrowers>()
                .HasKey(e => new { e.BookId, e.BorrowerId, e.BorrowDate });

            base.OnModelCreating(modelBuilder);
        }
    }
}
