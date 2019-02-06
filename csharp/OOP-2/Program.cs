using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace OOP_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new SetArray(6);
            Console.WriteLine("Numbers Randomized");

            foreach (var i in arr.Numbers)
            {
                Console.Write(i + "|");
            }
            Console.WriteLine();

            Console.Write("Number Of 0 : " + arr.NumberOf0 + "\n");
            Console.Write("Number of Odd : " + arr.NumberOdd() + "\n");

            Console.WriteLine("Substracted Array");
            foreach (var i in arr.Substract())
            {
                Console.Write(i + "|");
            }
            Console.WriteLine();
        }

    }
}
