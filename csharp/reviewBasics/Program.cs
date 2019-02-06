using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reviewBasics
{

    struct Name_Phone
    {
        public string name;
        public float price;
    }

    class Program
    {
        static void Main(string[] args)
        {
            ///////////////////Array///////////////
            // jagged array
            var jaggedArray = new int[3][];
            jaggedArray[0] = new int[4];
            jaggedArray[1] = new int[5];
            jaggedArray[2] = new int[4];
            jaggedArray[0][0] = 1;

            // retancular array
            var numbers = new[] { 1, 2, 3, 4 };
            Console.WriteLine("Length: {0}", numbers.Length);

            // index of
            Array.IndexOf(numbers, 1);

            // clear() /// clear means set int to 0, bool to false, object to null
            Array.Clear(numbers, 0, 2);
            foreach(var num in numbers)
                Console.WriteLine(num);

            /// copy() numbers from one array to another
            var another = new int[3];
            Array.Copy(numbers, another, 3); // from numbers to another

            // sort method
            Array.Sort(numbers);
            // reverse opposite of above


            //////////////////////// List /////////////////////
            Name_Phone phone1;
            Name_Phone phone2;          
            var phone = new List<Name_Phone>();
            phone1 = new Name_Phone { name = "iPhone", price = 1.02f };
            phone2 = new Name_Phone { name = "samsung", price = 1.03f };
            phone.Add(phone1);
            phone.Add(phone2);
            //Console.WriteLine(phone.Count);
            phone.RemoveAt(0);
            //Console.WriteLine(phone.Count);

            /// addRange   you add list or array to array!
            var list = new List<int>();
            list.AddRange(new int[3] { 3, 2, 3 });
            foreach(var num in list)
                Console.WriteLine(num);

            /// index of search for something lastIndexOF
            var indexOfelOrBoolen = list.IndexOf(3);
            var fromBackStartSearch = list.LastIndexOf(3);

            if (indexOfelOrBoolen == -1)
                Console.WriteLine("Not found");
            else
                Console.WriteLine(indexOfelOrBoolen);

            ////////Remove /////////////////////////      
            foreach (var num in list) {
                if (num == 1)           //// you can not do that!!! this is c#
                    list.Remove(num);
            }

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] == 1)           //// you can  do that!!!
                    list.Remove(list[i]);
            }
            /////////////////////////////////



            //////////////DateTime

            var dateTime = new DateTime(2010, 1, 23);
            var now = DateTime.Now;
            var today = DateTime.Today;
            Console.WriteLine(now + " : "  + today);
            var tommorrow = now.AddDays(1);



            



            Console.ReadKey();
        }
    }
}
