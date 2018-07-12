namespace P01_StudentSystem.Data.EntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(e => e.CourseId);

            builder.Property(e => e.Name)
                .HasMaxLength(80)
                .IsUnicode();

            builder.Property(e => e.Description)
                .IsUnicode()
                .IsRequired(false);

            builder.Property(e => e.StartDate)
                .IsRequired();

            builder.Property(e => e.EndDate)
                .IsRequired();

            builder.Property(e => e.Price)
                .IsRequired();
        }
    }
}