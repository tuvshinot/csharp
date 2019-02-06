using System.Linq;


namespace Queries
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new PlutoContext();

            #region LINQ QUERY
            #region Quick Overview LINQ Query and Extension Method
            // LINQ QUERY
            /*var query =
                from c in context.Courses
                where c.Name.Contains("c#")
                orderby c.Name
                select c;

            foreach(var course in query)
                System.Console.WriteLine(course.Name);

            // Extension methods
            System.Console.WriteLine("Extension method!");
            var courses = context.Courses
                .Where(c => c.Name.Contains("c#"))
                .OrderBy(c => c.Name);
            foreach (var course in courses)
            {
                System.Console.WriteLine(course.Name);
            }
            */
            #endregion

            #region Projection
            // Projection
            var query =
                from c in context.Courses
                where c.AuthorId == 1
                orderby c.Name descending, c.Level
                //select c --- do not send them all properties take some time so PROJECTION
                select new { Name = c.Name, Author = c.Author.Name };
                            /// we got the courses
            #endregion

            #region Group By
            // Group by level
            var query1 =
                from c in context.Courses
                group c by c.Level
                into g // put them into group
                select g; // select group

            foreach (var group in query1)
            {
                System.Console.WriteLine(group.Key); // key is in that case level property from course.level
                foreach (var course in group)
                {
                    System.Console.WriteLine("\t{0}", course.Name);
                }
            }

            // Count in groups aggregation functions
            foreach (var group in query1)
            {
                System.Console.WriteLine("{0} : {1}", group.Key, group.Count());
            }
            #endregion

            #region Joining
            // Inner Join -- sql equavalent
            var query2 =
                from c in context.Courses
                join a in context.Authors on c.Author.Id equals a.Id
                select new { CourseName = c.Name, Author = a.Name }; // they don`t have relationship
            // select new { CourseName = c.Name, Author = c.Author.Name }  it auto joins course and author
                                                                   // if it has relation ship 

            // Group Join -- dont have sql equavalent
            var query3 =
                from a in context.Authors
                join c in context.Courses on a.Id equals c.AuthorId into g
                select new { AuthorName = a.Name, Courses = g.Count() }; // returns list of
            //rightside author    // left side group of couses belongs to this author

            // Cross join
            var query4 =
                from c in context.Courses
                from a in context.Authors
                select new { AuthorName = a.Name, CourseName = c.Name };
            // returns list of 

            #endregion
            #endregion

            #region LINQ Extention method

            var courses = context.Courses
            .Where(c => c.Level == 1)

            // Order
            .OrderBy(c => c.Name) // first and 
            .ThenBy(c => c.Level) // then multiple parameter order by

            #region projection select select many
            //.Select(c => new { CourseName = c.Name, AuthorName = c.Author.Name }) // anonymous method
                .Select(c => c.Tags); // it returns list of list

            foreach (var c in courses)
            {
                foreach (var tag in c)
                {
                    System.Console.WriteLine(tag.Name);
                }
            }

            var tags = context.Courses
                .SelectMany(c => c.Tags)
                .Distinct(); // it removes doublication

            foreach (var tag in tags)
            {
                System.Console.WriteLine(tag.Name);
            }
            #endregion

            #region Groupby
            var groups = context.Courses
                .GroupBy(c => c.Level); // returns list of groups with key modifier, each group has its own courses

            foreach (var group in groups)
            {
                System.Console.WriteLine(group.Key);

                foreach (var course in group)
                {
                    System.Console.WriteLine(course.Name);
                }
            }
            #endregion

            #region Join

            // inner join when two tables do not have a relationship
            context.Courses.Join(context.Authors, c => c.Id, a => a.Id, (course, author) => new
            {
                CourseName = course.Name,
                AuthorId = author.Id
            });

            // Group Join
            context.Authors.GroupJoin(context.Courses, a => a.Id, c => c.AuthorId, (author, course) => new
            {
                AuthorName = author.Name,
                Courses = course.Count()
            });

            // cross join
            context.Authors.SelectMany(a => context.Courses, (author, course) => new
            {
                AuthorName = author.Name,
                courseName = course.Name
            });


            #endregion

            #region Additional Methods
            
            // Partitioning, image size of each page 10
            var coursesSecondPage = context.Courses.Skip(10).Take(10); // getting second page of courses

            //  Element operator -- returns single object
            context.Courses
                .OrderBy(c => c.Level)
                .FirstOrDefault(c => c.FullPrice < 10); // default returns null if not exists firstOrDefault()
            // last but you should order them descending and get first one


            // get single
            context.Courses.SingleOrDefault(c => c.Id == 1);

            // we can check all courses satisfying particular criteria
            context.Courses.All(c => c.FullPrice < 10);

            // check any
            context.Courses.Any(c => c.Name.Contains("gui"));


            // aggregating
            context.Courses.Count();

            // average min max
            context.Courses.Max(c => c.FullPrice); // most experience course example

            #endregion

            #endregion



        }
    }
}
