namespace P03_FootballBetting.Data.EntityConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(e => e.UserId);

            builder.Property(e => e.Username)
                .IsUnicode()
                .IsRequired();

            builder.Property(e => e.Password)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(e => e.Email)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(e => e.Name)
                .IsUnicode()
                .IsRequired();
        }
    }
}