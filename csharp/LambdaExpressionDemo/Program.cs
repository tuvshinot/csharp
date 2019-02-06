using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaExpressionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // anonymous methods - lambda express
            // args => expression

            // Example
            Func<int, int> square = number => number * number;
            Console.WriteLine(square(4));  // === Square(5)

            // () => without args
            // x => one args
            // (x, y) => multiple 


            // Example --- lambda express implementation are accessible to vars which in this scoupe
            const int factor = 5;
            Func<int, int> multiple = num => num * factor;

            Console.WriteLine(multiple(5));

            // Example
            // 1 - simple approach
            var books = new BookRepository().GetBooks();
            var UnderTenDollarBooks = books.FindAll(IsCheaperThan10Dollar);

            Console.WriteLine("Under 10 dollar!");
            foreach (var book in UnderTenDollarBooks)
                Console.WriteLine(book.Title);

            // 2 - lambda approach
            ///var books = new BookRepository().GetBooks();
            ///var UnderTenDollarBooks = books.FindAll(b => b.Price < 10) this is equvallent to Predicate method


        }

        // Predicate Method
        static bool IsCheaperThan10Dollar(Book book)
        {
            return book.Price < 10;
        }


        static int Square(int number)
        {
            return number * number;
        }
    }

    public class BookRepository
    {
        public List<Book> GetBooks()
        {
            return new List<Book>
            {
                new Book(){Title = "Book1", Price = 5},
                new Book(){Title = "Book2", Price = 12}
            };
        }
    }

    public class Book
    {
        public string Title { get; set; }
        public double Price { get; set; }
    }
}
