using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyWhyWeUSe
{
    class Program
    {
        public class Person
        {
            public Person()
            {

            }

            private DateTime _birthday;
            /// <summary>
            /// one way of setting!
            /// </summary>
            public DateTime Birthday
            {
                get { return _birthday; }
                set { _birthday = value; }
            }
            
            /// auto implemented propert
            public DateTime Birthday1 { get; set; } // c# auto creates private field


            public Person(DateTime dateTime)
            {
                dateTime = Birthday2;
            }
            public DateTime Birthday2 { get; private set; } // we cannot set that`s we can use ctor
            /// <summary>
            /// 
            /// </summary>

            public int Age
            {
                get
                {
                    var timeSpan = DateTime.Now - Birthday1;
                    var years = timeSpan.Days / 365;
                    return years;
                }
            }

        }


        static void Main(string[] args)
        {
            var person = new Person();
            person.Birthday1 = new DateTime(2010, 1, 1);
            Console.WriteLine(person.Age); // age should be calculated!! set is not for this one



        }
    }
}
