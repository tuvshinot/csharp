using System;

namespace DesignDBConnection
{
    public class SqlConnection : DBConnection
    {
        private readonly string connectionSting;

        public SqlConnection(string connectionSting)
            :base(connectionSting)
        {
            this.connectionSting = connectionSting;
        }

        public override void Opening()
        {
            Console.WriteLine("Openning Sql connection :" + connectionSting);
        }

        public override void Closing()
        {
            Console.WriteLine("Closing Sql connection :" + connectionSting);
        }
    }
}