using System.Data.Entity;
using CodeFirstExercies.EntityConfiguration;

namespace CodeFirstExercies
{
    public class VidzyDBContext : DbContext
    {
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<Tag> Tags { get; set; }

        public VidzyDBContext()
            : base("name=DefaultConnection")
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Video>()
                .HasMany(v => v.Tags)
                .WithMany(t => t.Videos)
                .Map(m => )
                        



            modelBuilder.Entity<Genre>()
                .Property(g => g.Name)
                .IsRequired()
                .HasMaxLength(255);


            modelBuilder.Configurations.Add(new VideoConfiguration());
        }
    }
}
