using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodAdvancedStuffs
{

    public class Point
    {
        public int X;
        public int Y;

        public Point(int x, int y)
        {

            this.X = x;
            this.Y = y;
        }

        public void Move(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public void Move(Point newLocation)
        {
            if (newLocation == null)
                throw new ArgumentNullException("New location");  /// defensive programming 
                   /// this is throw ex -> below method never will run and stays!

            Move(newLocation.X, newLocation.Y);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Try parse
            var result = int.TryParse("123123", out int number);
            if(result)
                Console.WriteLine(number);
            else
                Console.WriteLine("failed!");
        }


        static void Calc()
        {
            var calc = new Calculator();

            calc.Add(1, 2, 3, 5, 4, 5);
            calc.Add(new int[] { 1, 2, 3, 4, 5 });
        }

        static void UsePoints()
        {
            try
            {
                // Method Over loading!
                var point = new Point(10, 20);
                point.Move(new Point(20, 10));
                point.Move(10, 10);
            }
            catch (Exception)
            {
                Console.WriteLine("Unexpected error!");
            }
        }
    }
}
