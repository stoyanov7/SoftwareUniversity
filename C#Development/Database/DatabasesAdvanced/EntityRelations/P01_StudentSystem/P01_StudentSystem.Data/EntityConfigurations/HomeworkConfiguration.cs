namespace P01_StudentSystem.Data.EntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    public class HomeworkConfiguration : IEntityTypeConfiguration<Homework>
    {
        public void Configure(EntityTypeBuilder<Homework> builder)
        {
            builder.HasKey(e => e.HomeworkId);

            builder.Property(e => e.Content)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(e => e.ContentType)
                .IsRequired();

            builder.Property(e => e.SubmissionTime)
                .IsRequired();

            builder.Property(e => e.StudentId)
                .IsRequired();

            builder.HasOne(e => e.Student)
                .WithMany(s => s.HomeworkSubmissions)
                .HasForeignKey(e => e.StudentId);

            builder.Property(e => e.CourseId)
                .IsRequired();

            builder.HasOne(e => e.Course)
                .WithMany(c => c.HomeworkSubmissions)
                .HasForeignKey(e => e.CourseId);
        }
    }
}