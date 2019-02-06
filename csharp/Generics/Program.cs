using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// where T : IComparable
// where T : Product
// where T : struct /// ____________ value type , struct is value type, class reference type
// where T : class
// where T : new()

namespace GenericsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // : struct
            // struct other word value type can be nullable
            var number = new Nullable<int>(5);
            Console.WriteLine(number.HasValue); // true
            Console.WriteLine(number.GetValueOrDefault()); // 5

            var num = new Nullable<int>();
            Console.WriteLine(number.HasValue); // false 
            Console.WriteLine(number.GetValueOrDefault()); // 0 --- coolr

        }
    }
}
