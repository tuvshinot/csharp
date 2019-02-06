using System;
using System.Threading;

namespace DesignDBConnection
{
    public class OracleConnection : DBConnection
    {
        private readonly string connectionSting;

        public OracleConnection(string connectionSting)
            : base(connectionSting)
        {
            this.connectionSting = connectionSting;
        }

        public override void Opening()
        {
            if (running)
                throw new InvalidCastException("Openned already!");
            running = true;
            Console.WriteLine("Openned Oracle connection : " + connectionSting);
        }

        public override void Closing()
        {
            if (running)
            {
                Console.WriteLine(connectionSting + " is closing in ");

                for (int i = TimeOut.Seconds; i >= 0; i--)
                {
                    Thread.Sleep(500);
                    Console.WriteLine(i);
                }

                Console.WriteLine(connectionSting + " is closed!");
            }

            else
            {
                Console.WriteLine(connectionSting + " is Not openned!");
            }
        }

    }
}