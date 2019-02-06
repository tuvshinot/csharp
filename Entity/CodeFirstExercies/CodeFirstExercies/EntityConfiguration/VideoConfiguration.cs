using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace CodeFirstExercies.EntityConfiguration
{
    class VideoConfiguration :EntityTypeConfiguration<Video>
    {
        public VideoConfiguration()
        {
            ToTable("tbl_Video");
            HasKey(c => c.Id);

            Property(v => v.Name)
                .IsRequired()
                .HasMaxLength(255);

            HasRequired(v => v.Genre)
                .WithMany(g => g.Videos)
                .HasForeignKey(v => v.GenreId);
                
        }
    }
}
