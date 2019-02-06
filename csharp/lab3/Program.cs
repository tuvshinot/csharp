using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace lab3
{
    public class Pill
    {
        public string PillName { get; set; }
        public string Manufacture { get; set; }
        public double  Price { get; set; }
        public string  DrugStoreName { get; set; }
    }

    public class DrugStore
    {
        // drug store pills
        private List<Pill> _pills;
        public string Name { get; set; }
        public string Location { get; set; }

        public int NumberOfPills
        {
            get { return _pills.Count; }
        }

        public DrugStore()
        {
            _pills = new List<Pill>();
        }

        public Pill this[int key]
        {
            get { return _pills[key]; }
            set { _pills.Add(value); }
        }
    }

    public class DrugStoreNetwork
    {
        private List<DrugStore> _drugStores;

        public int NumberOfStores
        {
            get { return _drugStores.Count;}
        }

        public DrugStoreNetwork()
        {
            _drugStores = new List<DrugStore>();
        }

        public DrugStore this[int key]
        {
            get { return _drugStores[key]; }
            set { _drugStores.Add(value); }
        }

    }


    class Program
    {
        static void Main(string[] args)
        {
            DrugStoreNetwork Drugnetwork = new DrugStoreNetwork();

            //C:\Users\user\Desktop\log.txt
            var running = true;

            while (running)
            {
                Restart:

                try
                {
                    Start:
                    Console.WriteLine();
                    Console.WriteLine("1:File \n2:DrugStores \n3:Search");
                    var ans = Convert.ToInt16(Console.ReadLine());

                    switch (ans)
                    {
                        case 1:
                            //insert from file or save to file
                            FileMenu:
                            Console.WriteLine();
                            Console.WriteLine("0:Save \n1:Open DrugStore \n2:back");
                            var fileAns = Convert.ToInt16(Console.ReadLine());
                            switch (fileAns)
                            {
                                // Save Existing DB to File
                                case 0:
                                    if (Drugnetwork.NumberOfStores == 0)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("DataBase Empty !!! ");
                                        Console.ResetColor();
                                        goto FileMenu;
                                    }
                                    Save(Drugnetwork);

                                    break;
                                // Open DrugStore and add to DB
                                case 1:
                                    OpenDrugStore(Drugnetwork);
                                    goto Start;
                                // open pills and add to existing drugstore
                                case 2:
                                    goto Start;
                                default:
                                    goto Start;
                            }

                            goto Start;
                        case 2 :
                            Menu:

                            // get answer
                            var input = DisplayDB(Drugnetwork);

                            // add drugStore
                            if (input == 0)
                            {
                                Add(Drugnetwork);
                                goto Menu;
                            }

                            // add medicine to drugStore
                            if (input == 1)
                            {
                                // check if there is a drug store
                                if (Drugnetwork.NumberOfStores == 0)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("There is no Drug Store !!! ");
                                    Console.ResetColor();
                                    goto Menu;
                                }
                                // add medicine to 
                                AddMedicineToStore(Drugnetwork);
                                goto Menu;
                            }

                            // back
                            if (input == 2)
                            {
                                // back
                                goto Start;
                            }

                            break;
                        case 3: 
                            // Search
                            var foundPills = SearchForMedicine(Drugnetwork);
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            for (int i = 0; i < foundPills.Count; i++)
                            {
                                Console.WriteLine("Pill Name: {0} --- DrugStore Name : {1}", foundPills[i].PillName, foundPills[i].DrugStoreName);
                            }
                            Console.ResetColor();
                            goto Start;
                    }
                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid Input! ");
                    Console.ResetColor();
                }
                
            }
        }

        static void OpenDrugStore(DrugStoreNetwork network)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine();
            Console.WriteLine("Insert path to file");
            Console.ResetColor();
            var _path = Console.ReadLine();


            using (StreamReader sr = File.OpenText(_path))
            {
                string s = "";

                while ((s = sr.ReadLine()) != null)
                {
                    string[] temp = s.Split(',');
                    DrugStore store = new DrugStore()
                    {
                        Name = temp[0],
                        Location = temp[1]
                    };

                    Pill pill = new Pill()
                    {
                        PillName = temp[2],
                        Manufacture = temp[3],
                        Price = Convert.ToInt16(temp[4])
                    };

                    store[store.NumberOfPills] = pill;
                    network[network.NumberOfStores] = store;
                }
            }

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Added Drugstore from " + _path + " Successfully!");
            Console.ResetColor();
        }

        static void Save(DrugStoreNetwork network)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Insert Save path");
            Console.ResetColor();
            var _path = Console.ReadLine();
            using (var streamWriter = new StreamWriter(_path, true))
            {
                for (int i = 0; i < network.NumberOfStores; i++)
                {
                    var store = network[i];

                    for (int j = 0; j < store.NumberOfPills; j++)
                    {
                        streamWriter.WriteLine(store.Name + " : " + store[j].PillName);
                    }
                }
            }

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Saved to " + _path + " Successfully!");
            Console.ResetColor();
        }

        static void AddMedicineToStore(DrugStoreNetwork network)
        {
            Console.WriteLine();
            for (int i = 0; i < network.NumberOfStores; i++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                var store = network[i];
                Console.WriteLine(i + " : " + store.Name);
            }

            Console.WriteLine();
            Console.WriteLine("Insert Index of DrugStore to Add : ");
            var index = Convert.ToInt16(Console.ReadLine());
            var pillAddingToStore = network[index];
            var currentNumberOfPills = pillAddingToStore.NumberOfPills;
            
            //checking
            var added = false;
            var pillname = GetNonNumberValue("Name");
            for (int i = 0; i < pillAddingToStore.NumberOfPills; i++)
            {
                if (pillAddingToStore[i].PillName == pillname)
                {
                    added = true;
                }
            }

            if (!added)
            {
                pillAddingToStore[currentNumberOfPills] = new Pill()
                {
                    PillName = pillname,
                    Manufacture = GetNonNumberValue("Manufacture"),
                    Price = GetNumberValue("Price"),
                    DrugStoreName = pillAddingToStore.Name
                };
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Pill Added successfully to |" + pillAddingToStore.Name + "|");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Pill Added Already to|" + pillAddingToStore.Name + "|");
                Console.ResetColor();
            }
        }

        static void Add(DrugStoreNetwork network)
        {
            var added = false;
            var drugStoreName = GetNonNumberValue("Drugstore Name ");

            // checking
            for (int i = 0; i < network.NumberOfStores; i++)
            {
                var store = network[i];
                if (store.Name == drugStoreName)
                {
                    added = true;
                }
            }

            if (!added)
            {
                var numberOfPills = GetNumberValue("How many pills");
                var locationDrugStore = GetNonNumberValue("Where Drug store locate ");

                var drugStore = new DrugStore
                {
                    Name = drugStoreName,
                    Location = locationDrugStore
                };

                // insert pill according to user give
                Console.WriteLine("Insert {0} Pills ", numberOfPills);
                for (int i = 0; i < numberOfPills; i++)
                {
                    // using indexer to access private arrays
                    drugStore[i] = new Pill
                    {
                        PillName = GetNonNumberValue("Name"),
                        Manufacture = GetNonNumberValue("Manufacture"),
                        Price = GetNumberValue("Price"),
                        DrugStoreName = drugStore.Name
                    };
                }

                network[network.NumberOfStores] = drugStore;
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Added successfully");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(drugStoreName + " is already added!!!");
                Console.ResetColor();
            }
        }

        static List<Pill> SearchForMedicine(DrugStoreNetwork network)
        {
            Console.WriteLine();
            Console.Write("Searching(Pill Name) : ");
            var pillLookingFor = Console.ReadLine();
            var foundPills = new List<Pill>();


            for (int i = 0; i < network.NumberOfStores; i++)
            {
                for (int j = 0; j < network[i].NumberOfPills; j++)
                {
                    if (network[i][j].PillName.ToLower().Contains(pillLookingFor))
                    {
                       foundPills.Add(network[i][j]);
                    }
                }
            }

            return foundPills;
        }

        static int DisplayDB(DrugStoreNetwork network)
        {
            if (network.NumberOfStores == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("DataBase Empty !!! ");
                Console.ResetColor();
            }

            for (int i = 0; i < network.NumberOfStores; i++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                var store = network[i];
                Console.WriteLine(i + " : " + store.Name);

                Console.ForegroundColor = ConsoleColor.Blue;
                for (int j = 0; j < store.NumberOfPills; j++)
                {
                    Console.Write("|" + store[j].PillName);
                }

                Console.WriteLine();
            }

            Console.WriteLine();
            Console.ResetColor();
            Console.WriteLine("0:Add drugStore \n1:Add Medicine to DrugStore \n2:back");
            return Convert.ToInt16(Console.ReadLine());
        }

        static double GetNumberValue(string question)
        {
            Console.Write(question + " : ");
            return Convert.ToDouble(Console.ReadLine());
        }

        static string GetNonNumberValue(string question)
        {
            Console.Write(question + " : ");
            return Console.ReadLine().ToString();
        }
    }
}
