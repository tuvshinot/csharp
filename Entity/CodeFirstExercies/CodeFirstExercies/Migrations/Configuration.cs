namespace CodeFirstExercies.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Collections;
    using System.Collections.ObjectModel;

    internal sealed class Configuration : DbMigrationsConfiguration<CodeFirstExercies.VidzyDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CodeFirstExercies.VidzyDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            //context.Genres.AddOrUpdate(
            //    g => g.Id,
            //    new Genre
            //    {
            //        Name = "Horror",
            //        Videos = new Collection<Video>()
            //        {
            //            new Video(){ Name = "Aimshig", ReleaseDate = DateTime.Now},
            //            new Video(){ Name = "Suns", ReleaseDate = DateTime.Now}
            //        }
            //    },
            //    new Genre
            //    {
            //        Name = "Music",
            //        Videos = new Collection<Video>()
            //        {
            //            new Video(){ Name = "Beyonce", ReleaseDate = DateTime.Now},
            //            new Video(){ Name = "Ice Top", ReleaseDate = DateTime.Now}
            //        }
            //    },
            //    new Genre
            //    {
            //        Name = "Tv Show",
            //        Videos = new Collection<Video>()
            //        {
            //            new Video(){ Name = "Tonight show", ReleaseDate = DateTime.Now},
            //            new Video(){ Name = "Ellen show", ReleaseDate = DateTime.Now}
            //        }
            //    }
            //);
        }
    }
}
