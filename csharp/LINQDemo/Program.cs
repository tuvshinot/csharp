using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQDemo
{
    public class Book
    {
        public string Title { get; set; }
        public float Price { get; set; }
    }

    public class BookRepository
    {
        public IEnumerable<Book> GetBooks()
        {
            return new List<Book>()
            {
                new Book(){Title = "BBook", Price = 5},
                new Book(){Title = "ABook", Price = 9.99f},
                new Book(){Title = "CBook", Price = 12},
                new Book(){Title = "EBook", Price = 7},
                new Book(){Title = "DBook", Price = 9}
            };
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var books = new BookRepository().GetBooks();

            /// LINQ Query Operator
            var cheaperBooks =
                from b in books
                where b.Price < 10
                orderby b.Title
                select b.Price;


            /// LINQ Extension Method
            var cheapbooks = books
                .Where(b => b.Price < 10)
                .OrderBy(b => b.Title)
                .Select(b => b.Title); // only gets title!

            /// Get only one book
            /// I know only one we have
            var singleBook = books.Single(b => b.Title == "CBook");
            /// not sure there is or not
            var singleOrDefaultBook = books.SingleOrDefault(b => b.Title == "CBook"); // not returns default Ex: string - null

            /// First or Default, Last or Default
            var skiped = books.Skip(2).Take(2);
            var maxPrice = books.Max(b => b.Price);
            var mixPrice = books.Min(b => b.Price);
            var sum = books.Sum(b => b.Price);
            var average = books.Average(b => b.Price);

            foreach (var book in cheapbooks)
                Console.WriteLine(book);
                //Console.WriteLine(book.Title +  " : " + book.Price);
        }
    }
}
