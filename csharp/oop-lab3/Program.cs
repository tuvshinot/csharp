using System;
using System.Threading;

namespace oop_lab3
{
    
    namespace ThreadDemo
    {
        class ThreadDemoApp
        {
            public static void MyThread()
            {
                Console.WriteLine("MyThread: Thread Gone!");
            }

            [STAThread] //необязательное поле
            static void Main(string[] args)
            {
                ThreadStart myThreadDelegate = new ThreadStart(MyThread);
                Thread thr = new Thread(myThreadDelegate);
                Console.WriteLine("Start! MyThread");
                thr.Start();

            }
        }
    } 
}
