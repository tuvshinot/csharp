using System;
using System.Threading;

namespace DesignDBConnection
{
    public class DbCommand
    {
        public string Instraction { get; }

        public DbCommand(string instraction)
        {
            Instraction = instraction;
        }

        public void Execute(DBConnection dbConnection)
        {
            dbConnection.Opening();
            Run();
            dbConnection.Closing();
        }

        void Run()
        {
            Console.WriteLine("Instraction running!...");
            Thread.Sleep(3000);
        }
    }
}