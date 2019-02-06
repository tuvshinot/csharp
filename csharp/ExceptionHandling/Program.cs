using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling
{
    public class Calculator
    {
        public int Divide(int numerator, int denumerator)
        {
            return numerator / denumerator;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            // Exception from specific to general
            try
            {
                var cal = new Calculator();
                cal.Divide(5, 0);
            }

            catch (DivideByZeroException ex)
            {
                Console.WriteLine("You can not get result divided by 0");
            }

            catch (ArithmeticException e)
            {
            }

            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }


            /// Unmanaged resorces like stream reader or db connection, in finally block make sure you close them
            /// cuz you left resource open that so bad
            /// but using statement under the hood call finally block and dispose it!!!!!!!!!

            try
            {
                using (StreamReader reader = new StreamReader(@"sds.txt"))
                {
                    reader.ReadToEnd();
                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }
    }
}
