using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;

namespace oopLab1
{
    struct Name_Phone
    {
        public string name;
        public string manufac;
        public int price;
        public int release;
    }


    class Program
    {

        static void Main(string[] args)
        {
            var DB = new List<Name_Phone>();
            var running = true;


            while (running)
            {
                Restart:
                try
                {
                    // Program starts so there is no phone.
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Choose the number to insert command! ");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("\n 0:Add New Phone \n 1:exit \n ");
                    var output = Convert.ToInt16(Console.ReadLine());

                    // add new phone
                    if (output == 0)
                    {
                        Add:
                        // create phone and add to DB
                        DB.Add(CreatePhone());
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Added Succesfully!");
                        
                        // show phones we have
                        Console.WriteLine(" ");
                        Console.WriteLine("All phones:");
                        foreach (var phone in DB)
                        {
                            Console.WriteLine(phone.name + "---" + phone.manufac + "---" + phone.price + "---" + phone.release);

                        }
                        Console.WriteLine();

                        Menu:

                        // ask what to do next
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("0:Add New phone \n1:Delete phone \n2:Sort phone  \n3:Search Phone  \n4:See All phones  \n5:Exit ");
                        try
                        {
                            var answer = Convert.ToInt16(Console.ReadLine());
                            
                            // if choose add then goto start
                            if (answer == 0)
                            {
                                goto Add;
                            }

                            // if delete phone then choose one to delete
                            else if (answer == 1)
                            {
                                // show all phones with index
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine();
                                for (int i = 0; i < DB.Count; i++)
                                {
                                    Console.WriteLine(i + " : " + DB[i].name);
                                }

                                Console.WriteLine("");
                                Console.WriteLine("Which one to delete?");
                                var indexOfDelPhone = Convert.ToInt16(Console.ReadLine());
                                DB.RemoveAt(indexOfDelPhone);
                                Console.WriteLine(DB[indexOfDelPhone].name + " is deleted!");

                                // add to string
                                Console.WriteLine();
                                goto Menu;
                            }

                            // sort phones
                            else if (answer == 2)
                            {
                                // if phones less than 2
                                if (DB.Count < 2)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Only One phone in Database!");
                                    goto Menu;
                                }

                                // sort phones
                                var sortedDB = SortPhone(DB);

                                // list sorted phones
                                int inc = 0;

                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Phones are Sorted Successfully!");
                                foreach (var phone in sortedDB)
                                {
                                    Console.WriteLine(inc + " : " + phone.name);
                                    inc++;
                                }
                                Console.WriteLine();
                                // back to menu
                                goto Menu;
                            }

                            // Search phone
                            else if (answer == 3)
                            {
                                try
                                {
                                    // search from DB using phone name
                                    var allMatchedPhones = SearchPhone(DB);

                                    // if there is phone you looked for
                                    if (allMatchedPhones.Count != 0)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine();
                                        Console.WriteLine("Searched Successfully!");
                                        foreach (var phone in allMatchedPhones)
                                        {
                                            Console.WriteLine(phone.name + "---" + phone.manufac + "---" + phone.price + "---" + phone.release);
                                        }
                                        Console.WriteLine();
                                        goto Menu;
                                    }

                                    // if there is no phone looked for
                                    else
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Phone Not Found!!!");
                                        Console.WriteLine();
                                        goto Menu;
                                    }
                                }
                                catch (Exception e)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Invalid Cannot Search!");
                                }
                            }

                            // show all phones
                            else if (answer == 4)
                            {
                                Console.WriteLine();
                                Console.WriteLine("All phones:");
                                Console.ForegroundColor = ConsoleColor.Green;
                                foreach (var phone in DB)
                                {
                                    Console.WriteLine(phone.name + "---" + phone.manufac + "---" + phone.price + "---" + phone.release);
                                }
                                Console.WriteLine(" ");
                                goto Menu;
                            }

                            else if (answer == 5)
                            {
                                running = false;
                                return;
                            }

                        }
                        catch (Exception e)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("");
                            Console.WriteLine("Invalid input");
                            goto Menu;
                        }
                    }

                    // exit
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Done");
                        running = false;
                    }
                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("insert index of your answer!!! EX: 0");
                    goto Restart;
                }
            }

            Console.ResetColor();
            Console.Clear();
            Console.ReadKey();
        }

        static Name_Phone CreatePhone()
        {        
            string name;
            string manufac;
            int price;
            int release;
            
            Start:
                try
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Name: ");
                    name = Console.ReadLine();
                    Console.Write("manufac: ");
                    manufac = Console.ReadLine();
                    Console.Write("price: ");
                    price = Convert.ToInt16(Console.ReadLine());
                    Console.Write("relase: ");
                    release = Convert.ToInt16(Console.ReadLine());

                    return new Name_Phone
                    {
                        name = name,
                        price = price,
                        manufac = manufac,
                        release = release
                    };
                }

                catch (Exception e)
                {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input"); 
                    goto Start;
                }
        }

        static List<Name_Phone> SortPhone(List<Name_Phone> DB)
        {
                List<Name_Phone> sortedList = new List<Name_Phone>();

            // ask which feature sort by
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(" ");
                Console.WriteLine("Which Feature sort By? Write down...");

                // get feature to sort by
                Console.Write("EX: (0:name, 1:price, 2:manufac, 3:release)  : ");
                var sortFeature = Convert.ToInt16(Console.ReadLine());

                // if name
                if (sortFeature == 0)
                {
                    sortedList = DB.OrderBy(phone => phone.name).ToList();
                }

                // price
                else if (sortFeature == 1)
                {
                    sortedList = DB.OrderBy(phone => phone.price).ToList();
                }

                // manufac
                else if (sortFeature == 2)
                {
                    sortedList = DB.OrderBy(phone => phone.manufac).ToList();
                }

                // release
                else if (sortFeature == 3)
                {
                    sortedList = DB.OrderBy(phone => phone.release).ToList();
                }

                return sortedList;

        }

        static List<Name_Phone> SearchPhone(List<Name_Phone> DB)
        {
            
                var matchedPhones = new List<Name_Phone>();

            // ask User to insert phone you looking for
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(" Insert The name? : ");

                var searchInput = Console.ReadLine().ToString();

                foreach (var phone in DB)
                {
                    if (phone.name == searchInput)
                        matchedPhones.Add(phone);
                }

                return matchedPhones;
        }
    }
}
