namespace TeamBuilder.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    internal class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.HasKey(t => t.Id);

            builder.HasIndex(u => u.Name)
                .IsUnique();

            builder.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(25);

            builder.Property(t => t.Description)
                .HasMaxLength(32);

            builder.Property(t => t.Acronym)
                .IsRequired();

            builder.HasMany(e => e.UserTeams)
                .WithOne(t => t.Team)
                .HasForeignKey(t => t.TeamId);

            builder.HasMany(e => e.EventTeams)
                .WithOne(t => t.Team)
                .HasForeignKey(t => t.TeamId);
        }
    }
}