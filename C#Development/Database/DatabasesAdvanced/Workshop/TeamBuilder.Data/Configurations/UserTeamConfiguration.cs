namespace TeamBuilder.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    internal class UserTeamConfiguration : IEntityTypeConfiguration<UserTeam>
    {
        public void Configure(EntityTypeBuilder<UserTeam> builder)
        {
            builder.HasKey(e => new { e.TeamId, e.UserId });

            builder.HasOne(e => e.User)
                .WithMany(u => u.CreatedUserTeams)
                .HasForeignKey(ut => ut.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Team)
                .WithMany(t => t.UserTeams)
                .HasForeignKey(e => e.TeamId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}