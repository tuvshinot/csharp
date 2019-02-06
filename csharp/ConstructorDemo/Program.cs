using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructorDemo
{
    public class Costumer
    {
        private string Name;
        private int Id;
        public List<Order> Orders;

        // constructor overloading!
        public Costumer()
        {
            // default constructor // when code compile that sets all to int -> 0, string -> null
            Orders = new List<Order>();  // if we want list initialized when class called, make sure all constructor initizlize it so!!:
        }

        // ctor is code snippet for constructor 

        public Costumer(string name)
            :this()// calls default constructor
        {
            Name = name; // get from the outside
        }

        public Costumer(int id, string name)
            :this(name) // call constructor with name so name will be initialized!!
        {
            Id = id; // get from the outside
        }
    }

    public class Order
    {
        public string name;
    }

    class Program
    {
        static void Main(string[] args)
        {
            /// You have to remember that you have to initialize list and other data structure!!! see default constructor!!!
            var costumor = new Costumer();
            costumor.Orders.Add(new Order { name = "Product" });
            /// if we did not initialize list order in default can not be!
        }
    }
}
