using System;

namespace DesignDBConnection
{
    public abstract class DBConnection
    {
        private string ConnectionString { get; set; }
        public TimeSpan TimeOut { get; set; }
        public bool running { get; set; }

        protected DBConnection(string connectionString)
        {
            if(string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentNullException("Can not be null or white space!!!!!!!!!!!!!!!!");

            ConnectionString = connectionString;
        }

        public abstract void Opening();
        public abstract void Closing();

        public void SeeCurrentConnectionName()
        {
            Console.WriteLine(ConnectionString);
        }

    }
}