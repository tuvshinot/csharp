using System;
using System.Collections.Generic;

namespace CodeFirstExercies
{
    public class Video
    {
        public Video()
        {
            Tags = new HashSet<Tag>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
        public Classification Classification { get; set; }
        public ICollection<Tag> Tags { get; set; }
    }

    public class Tag
    {
        public Tag()
        {
            Videos = new HashSet<Video>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Video> Videos { get; set; }
    }

}
