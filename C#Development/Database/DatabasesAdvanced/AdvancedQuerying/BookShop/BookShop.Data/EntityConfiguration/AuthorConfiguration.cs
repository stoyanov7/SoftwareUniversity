namespace BookShop.Data.EntityConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(e => e.AuthorId);

            builder.Property(e => e.FirstName)
                .IsRequired(false)
                .IsUnicode()
                .HasMaxLength(50);

            builder.Property(e => e.LastName)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(50);
        }
    }
}