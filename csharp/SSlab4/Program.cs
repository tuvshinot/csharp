using System;
using System.Threading;
using System.Diagnostics;

namespace SSlab4
{
   /// <summary>
   /// Boss
   /// </summary>

    class Program
    {
        public static Semaphore InputLimit = new Semaphore(3, 3, "EmployeeInputLimit");

        static void Main(string[] args)
        {
            EventWaitHandle FirstEvent = new EventWaitHandle(false, EventResetMode.ManualReset, "OneEvent");
            EventWaitHandle SecondEvent = new EventWaitHandle(false, EventResetMode.ManualReset, "TwoEvent");
            EventWaitHandle ThirdEvent = new EventWaitHandle(false, EventResetMode.ManualReset, "ThreeEvent");
            EventWaitHandle EndEvent = new EventWaitHandle(false, EventResetMode.ManualReset, "EndEvent");

            int EmpNum = 0;
            Console.Write("Insert Number Process Employee: ");
            while (!Int32.TryParse(Console.ReadLine(), out EmpNum))
                Console.Write("Invalid Input...\nInsert Number Process Employee: ");
            for (int i = 0; i < EmpNum; i++)
                Process.Start(@"C:\Users\user\source\repos\csharp\Employee\bin\Debug\Employee.exe", ("Employee #" + (i + 1)));
            Console.WriteLine("Process Boss began work...");
            while (true)
            {
                bool Exit = false;
                int EventInex = WaitHandle.WaitAny(new WaitHandle[] { FirstEvent, SecondEvent, ThirdEvent, EndEvent });

                switch (EventInex)
                {
                    case 0:
                        Console.Write("1");
                        FirstEvent.Reset();
                        InputLimit.Release();
                        break;
                    case 1:
                        Console.Write("2");
                        SecondEvent.Reset();
                        InputLimit.Release();
                        break;
                    case 2:
                        Console.Write("3");
                        ThirdEvent.Reset();
                        InputLimit.Release();
                        break;
                    case 3:
                        EndEvent.Reset();
                        InputLimit.Release();
                        EmpNum--;
                        if (EmpNum == 0)
                            Exit = true;
                        break;
                }
                if (Exit)
                    break;
            }
            Console.WriteLine("Process Boss done!...");
            Console.ReadKey();
        }
    }
}
