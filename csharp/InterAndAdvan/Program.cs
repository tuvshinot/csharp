using System;

namespace WhyWeStatic
{
    public class Person
    {
        public string Name;

        public void Introduce(string to)
        {
            Console.WriteLine("Hello {0}, I am {1}", to, Name);
        }

        public static Person Parse(string name)
        {
            var person = new Person();
            person.Name = name;

            return person;
        }   

    }


    class Program
    {
        static void Main(string[] args)
        {
            var person = new Person
            {
                Name = "Tuvshin!"
            };
            // that runs
            person.Introduce("Yuri");
            // but what if want to parse new object
            // badperson.Parse("John");
            // make parse method to static
            var dek = Person.Parse("Dek");
            dek.Introduce("lhagwa");

            Console.ReadKey();
        }
    }
}
