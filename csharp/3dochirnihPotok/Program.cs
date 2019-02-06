using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _3dochirnihPotok
{
    using System;
    using System.Threading;

    class MyThread
    {
        public int count;
        public Thread thrd;
        static bool stop;
        static string currentName;
        /* Создаем новый поток. Обратите внимание на то, что этот конструктор в действительности не запускает потоки на выполнение. */
        public MyThread(string name)
        {
            count = 0; thrd = new Thread(new ThreadStart(this.run));
            thrd.Name = name;
            currentName = name;
        } 
        // Начинаем выполнение нового потока.
        void run()
        {
            Console.WriteLine("Поток " + thrd.Name + " стартовал. ");
            do
            {
                count++;
                if (currentName != thrd.Name)
                {
                    currentName=thrd.Name;
                    Console.WriteLine("В потоке " + currentName);
                }
            } while(stop ==false && count < 1000000000);
            stop = true;
            Console.WriteLine("Поток " + thrd.Name + " завершен."); 
    }
}
    class PriorityDemo
    {
        public static void Main()
        {
                MyThread mtl = new MyThread("с высоким приоритетом");
                MyThread mt2 = new MyThread("с низким приоритетом"); 
                // Устанавливаем приоритеты.
                mtl.thrd.Priority = ThreadPriority.AboveNormal;
                mt2.thrd.Priority = ThreadPriority.BelowNormal; 
                // Запускаем потоки на выполнение.
                mtl.thrd.Start ();
                mt2.thrd.Start ();
                mtl.thrd.Join() ;
                mt2.thrd.Join () ;
                Console.WriteLine();
                Console.WriteLine("Поток " + mtl.thrd.Name + " досчитал до " + mtl.count);
                Console.WriteLine("Поток " + mt2.thrd.Name + " досчитал до " + mt2.count);
                Console.ReadKey();
        }

    }

}
