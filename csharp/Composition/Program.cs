using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composition
{

    /// <summary>
    /// One Common class which Logger!
    /// two class we need to log and it`s common so one class:
    /// </summary>
    /// you can understand that like it`s just passing the class to the other classes where this method can be used! 

    public class Logger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }


    public class DBMIgrator
    {
        private readonly Logger _Logger;

        public DBMIgrator(Logger _logger)
        {
            _Logger = _logger;
        }

        public void Migrate()
        {
            _Logger.Log(message: "we are migrating ....!");
        }
    }

  

    public class Installer
    {
        private readonly Logger logger;

        public Installer(Logger logger)
        {
            this.logger = logger;
        }

        public void Install()
        {
            logger.Log("We are installing...!");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            /// Write one method use that in different places!!! like you know

            var DbMigrator = new DBMIgrator(new Logger());
            DbMigrator.Migrate();

            var logger = new Logger();
            var installer = new Installer(logger);
            installer.Install();
        }
    }
}
