namespace BusTicketsSystem.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.FirstName)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(30);

            builder.Property(b => b.LastName)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(30);

            builder.Property(b => b.DateOfBirth)
                .HasColumnType("DATETIME2");

            builder.Property(b => b.Gender)
                .IsRequired();

            builder.HasOne(b => b.HomeTown)
                .WithMany(h => h.Customers)
                .HasForeignKey(b => b.HomeTownId);
        }
    }
}