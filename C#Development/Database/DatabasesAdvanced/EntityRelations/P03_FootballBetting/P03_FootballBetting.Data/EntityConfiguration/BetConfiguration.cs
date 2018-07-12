namespace P03_FootballBetting.Data.EntityConfiguration
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    public class BetConfiguration : IEntityTypeConfiguration<Bet>
    {
        public void Configure(EntityTypeBuilder<Bet> builder)
        {
            builder.HasKey(e => e.BetId);

            builder.Property(e => e.Prediction)
                .IsRequired();

            builder.Property(e => e.DateTime)
                .HasDefaultValue(DateTime.Now);

            builder.Property(e => e.UserId)
                .IsRequired();

            builder.HasOne(e => e.User)
                .WithMany(u => u.Bets)
                .HasForeignKey(e => e.UserId);

            builder.Property(e => e.GameId)
                .IsRequired();

            builder.HasOne(e => e.Game)
                .WithMany(g => g.Bets)
                .HasForeignKey(e => e.GameId);
        }
    }
}