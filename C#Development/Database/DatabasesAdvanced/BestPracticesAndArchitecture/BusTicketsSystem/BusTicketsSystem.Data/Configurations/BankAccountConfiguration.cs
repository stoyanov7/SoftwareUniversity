namespace BusTicketsSystem.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    public class BankAccountConfiguration : IEntityTypeConfiguration<BankAccount>
    {
        public void Configure(EntityTypeBuilder<BankAccount> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Balance)
                .IsRequired();

            builder.HasOne(b => b.Customer)
                .WithMany(b => b.BankAccounts)
                .HasForeignKey(b => b.CustomerId);
        }
    }
}