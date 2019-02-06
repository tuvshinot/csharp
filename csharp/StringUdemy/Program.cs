using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringUdemy
{
    class Program
    {
        static void Main(string[] args)
        {
            // trim removes first and last white space
            var fullname = " Tuvshin Ot ";
            Console.WriteLine(fullname);

            /// substring and index of
            var index = fullname.IndexOf(' ');
            var firstName = fullname.Substring(0, index);
            var lastName = fullname.Substring(index + 1); // start after index

            // split 
            var names = fullname.Split(' ');

            /// replace  returns new string
            var realName = fullname.Replace("Ot", "Otgonprev");
            Console.WriteLine(realName);

            /// to check string
            if(String.IsNullOrEmpty(" ".Trim()))
                Console.WriteLine("invalid");
            if (String.IsNullOrWhiteSpace(" "))
                Console.WriteLine("invalid");


            // starts with, index of , lastindex
            fullname.StartsWith("T");
            fullname.Contains("u");





            Console.ReadKey();

        }
    }
}
