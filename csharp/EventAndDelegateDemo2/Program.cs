using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodExtensionIEnumerableEx
{
    class Program
    {
        static void Main(string[] args)
        {
            var post = "This is going to be the very long post you should See!";
            var shortened = post.Shorten(5);

            // example
            IEnumerable<int> numbers = new List<int>() {1,2,3,4};
            Console.WriteLine(numbers.All(num => num > 0));
            Console.WriteLine(numbers.Any(num => num ==1));


            Console.WriteLine(shortened);
        }
    }

}

namespace System // see i used system namespace so that reachable extented method
{
    public static class StringExtensions
    {
        public static string Shorten(this String str, int numberOfWords)
        {
            if (numberOfWords < 0)
                throw new ArgumentOutOfRangeException("Can not be minus number");

            var words = str.Split(' ');

            if (str.Length < numberOfWords)
                return str;

            return string.Join(" ", words.Take(numberOfWords)) + "...";
        }
    }

}
