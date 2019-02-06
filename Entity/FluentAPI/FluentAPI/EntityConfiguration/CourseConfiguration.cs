using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentAPI.EntityTypeConfiguration
{
    class CourseConfiguration : EntityTypeConfiguration<Course> // it has directly access to course
    {
        public CourseConfiguration()
        {
            ToTable("tbl_Course");
            HasKey(c => c.Id);

            //modelBuilder.Entity<Course>()
            Property(c => c.Name)
           .IsRequired()
           .HasMaxLength(255);

            //modelBuilder.Entity<Course>()
            Property(c => c.Description)
            .IsRequired()
            .HasMaxLength(2000);

            // name of author_id to authorId
            //modelBuilder.Entity<Course>()
            HasRequired(c => c.Author) // goto author
            .WithMany(a => a.Courses) // get courses
            .HasForeignKey(c => c.AuthorId) // courses has foreignkey id
            .WillCascadeOnDelete(false); // can not delete if it has course

            // change tagCourses to CourseTags
            //modelBuilder.Entity<Course>()
            HasMany(c => c.Tags)
            .WithMany(t => t.Courses)
            .Map(m =>
            {
                m.ToTable("CourseTags");
                m.MapLeftKey("CourseId");
                m.MapRightKey("TagId");
            });

            // set one to one relationship course is parent one
            // modelBuilder.Entity<Course>()
            HasRequired(c => c.Cover)
            .WithRequiredPrincipal(c => c.Course);
        }
    }
}
