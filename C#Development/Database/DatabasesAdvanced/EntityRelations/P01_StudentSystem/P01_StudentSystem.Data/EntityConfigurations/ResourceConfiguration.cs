namespace P01_StudentSystem.Data.EntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    public class ResourceConfiguration : IEntityTypeConfiguration<Resource>
    {
        public void Configure(EntityTypeBuilder<Resource> builder)
        {
            builder.HasKey(e => e.ResourceId);

            builder.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode()
                .IsRequired();

            builder.Property(e => e.Url)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(e => e.ResourceType)
                .IsRequired();

            builder.Property(e => e.CourseId)
                .IsRequired();

            builder.HasOne(e => e.Course)
                .WithMany(c => c.Resources)
                .HasForeignKey(e => e.CourseId);
        }
    }
}