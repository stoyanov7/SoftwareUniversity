namespace BusTicketsSystem.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.DateAndTimeOfPublishing)
                .HasColumnType("DATETIME2")
                .HasDefaultValueSql("GETDATE()");

            builder.Property(b => b.Grade)
                .IsRequired();

            builder.HasOne(b => b.Customer)
                .WithMany(c => c.Reviews)
                .HasForeignKey(b => b.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(b => b.BusCompany)
                .WithMany(c => c.Reviews)
                .HasForeignKey(b => b.BusCompanyId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}