using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading;

namespace OneDochirnihPotok
{

    class MyThread
    {

        public int count;
        string thrdName;
        public MyThread(string name)
        {
            count = 0;
            thrdName = name;
        } // Начало (входная точка) потока.

        public void run()
        {
            Console.WriteLine(thrdName + " Started!.");
            do
            {
                Thread.Sleep(500);
                Console.WriteLine(" Thread " + thrdName + ", count =" + count);
                count++;
            } while(count < 10);
            Console.WriteLine(thrdName + " Done!.");
        }

    }

    class MultiThread
    {
        public static void Main()
        {
            Console.WriteLine("Basic thread started!."); 
            // Сначала создаем объект класса MyThread.
            MyThread mt = new MyThread("Thread1"); 
            // Затем из этого объекта создаем поток.
            Thread newThrd = new Thread(new ThreadStart(mt.run)); 
            // Наконец, запускаем выполнение потока.
            newThrd.Start();
            do
            {
                Console.Write(".");
                Thread.Sleep(100);
            } while (mt.count != 10);

            Console.WriteLine("basic done!.");
            Console.ReadKey();





        }

    }

}
