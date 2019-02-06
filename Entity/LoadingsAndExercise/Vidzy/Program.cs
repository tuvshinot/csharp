using System.Data.Entity;
using System.Linq;

namespace Vidzy
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new VidzyContext();
            //var videos = context.Videos.ToList(); // lazy loading with word virtual in video front of the property of genre

            //var videos = context.Videos.Include(v => v.Genre).ToList(); // eager loading 

            // explicit loading
            var genres = context.Genres.ToList();
            var genreIds = genres.Select(a => a.Id);
            //var videos = context.Videos.Where(v => genreIds.Contains(v.GenreId) && v.Name == "Funny"); 
            context.Videos.Where(v => genreIds.Contains(v.GenreId)).Load(); // load it to the genres


            foreach (var genre in genres)
            {
                int count = genre.Videos.Count();
                System.Console.WriteLine(genre.Name + "------------------------" + count);

                foreach (var video in genre.Videos)
                {
                    System.Console.WriteLine(video.Name);
                }
                System.Console.WriteLine("--------------------");
            }



        }
    }
}
