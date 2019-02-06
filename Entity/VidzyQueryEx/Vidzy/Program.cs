using System;
using System.Linq;

namespace Vidzy
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new VidzyContext();

            #region Exercise - 1
            // sort action videos sorted by name
            var actionMovies = context.Videos
                .Where(v => v.Genre.Name == "Action")
                .OrderBy(v => v.Name);

            foreach (var video in actionMovies)
            {
                System.Console.WriteLine(video.Name);
            }
            System.Console.WriteLine("-----------------------------------");
            #endregion

            #region Exercise - 2
            var GoldDramaByDate = context.Videos
                .Where(v => v.Genre.Name == "Drama" && v.Classification == Classification.Gold)
                .OrderByDescending(v => v.ReleaseDate);

            foreach (var drama in GoldDramaByDate)
            {
                System.Console.WriteLine(drama.Name);
            }
            System.Console.WriteLine("_________________________________________-");

            #endregion

            #region Exercise - 3

            var allMoviesProjected = context.Videos
                .Select(v => new { MovieName = v.Name, GenreMovie = v.Genre.Name });

            foreach (var movie in allMoviesProjected)
            {
                System.Console.WriteLine("{0} : {1}", movie.MovieName, movie.GenreMovie);
            }
            #endregion

            #region Exercise - 4

            var moviesGroupedByClassification = context.Videos
                .GroupBy(v => v.Classification)
                .Select(g => new // g has video with key
                {
                    Classification = g.Key.ToString(),
                    Videos = g.OrderBy(v => v.Name) // videos ordered by
                });


            Console.WriteLine("----------------------------------");
            Console.WriteLine("ALL MOVIES GROUPED BY CLASSIFICATION");
            foreach (var g in moviesGroupedByClassification)
            {
                Console.WriteLine("Classification: " + g.Classification);

                foreach (var v in g.Videos)
                    Console.WriteLine("\t" + v.Name);
            }
            #endregion


            // Exercise - 5

            var groups = context.Videos
                .GroupBy(v => v.Classification)
                .Select(g => new
                {
                    Classification = g.Key.ToString(),
                    Count = g.Count()
                });
            foreach (var group in groups)
            {
                Console.WriteLine(group.Classification + " : " + group.Count);
            }

            // Exercise - 6

            var SortedByGenreOrderedByHighest = context.Videos
                .GroupBy(v => v.Genre.Name)
                .OrderBy(g => g.Count())
                .Select(g => new
                {
                    Classification = g.Key.ToString(),
                    Count = g.Count()
                });

            foreach (var group in SortedByGenreOrderedByHighest)
            {
                Console.WriteLine("{0}({1})", group.Classification, group.Count);
            }
        }
    }
}
