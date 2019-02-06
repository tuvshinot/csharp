using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InterfaceAndExtend
{
    class Program
    {
        static void Main(string[] args)
        {
            // Use case for interface!!


            // first we can write on console
            var DbMigrator = new DbMigrator(new ConsoleLogger());
            DbMigrator.Migrate();

            // second we can write on file we did not touch migrate class itself
            var DbMig = new DbMigrator(new FileLogger(@"C:\Users\user\Desktop\log.txt"));
            DbMig.Migrate();

            // Changing behavior just extending method !!!!
            // using interface is open for extension! close for modification
            // Open close principle!
        }
    }
}
