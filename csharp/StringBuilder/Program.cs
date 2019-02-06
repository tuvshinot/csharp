using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace StringBuilderUdemy
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new StringBuilder("HEllo world!"); // starting string

            builder.Append('-', 10)
                .AppendLine()
                .Replace('-', '+')
                .Remove(0, 10)//first 10
                .Insert(0, new string('-', 10));

            //you can you indexer!
            Console.WriteLine(builder[1]);



            //Console.WriteLine(builder);
            Console.ReadKey();
        }
    }
}
