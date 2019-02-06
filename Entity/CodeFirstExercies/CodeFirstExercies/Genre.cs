using System.Collections.Generic;

namespace CodeFirstExercies
{
    public class Genre
    {
        public Genre()
        {
            Videos = new HashSet<Video>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Video> Videos { get; set; }
    }
}
