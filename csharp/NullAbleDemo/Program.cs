using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullAbleDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Nullable<DateTime> date = null
            DateTime? date = null;
            Console.WriteLine(date.HasValue);
            Console.WriteLine(date.GetValueOrDefault()); // safer

            // get value from nullable type
            DateTime? date1 = new DateTime(2012,12,12);
            DateTime date2 = date1.GetValueOrDefault();

            // convert back to
            DateTime? date3 = date2;


            DateTime date4;
            date4 = (date != null) ? date.GetValueOrDefault() : DateTime.Today; // tershary operator
            DateTime date5 = date ?? DateTime.Today; // if date has value get that otherwise default


            switch (Console.ReadLine())
            {
                case "one":
                case "two":
                    Console.WriteLine("One or two");
                    break;


                default:
                    break;
            }
        }
    }
}
