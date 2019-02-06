using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectReferenceTypeThatChangesValue
{
    public class Order
    {
        public string name;
    }

    class Program
    {
        static void Main(string[] args)
        {
            var order = new Order();
            order.name = "Tuvshin";

            var order1 = order;
            order1.name = "Anu";


            Console.WriteLine(order.name);
            
        }
    }
}
