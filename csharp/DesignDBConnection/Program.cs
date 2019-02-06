using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignDBConnection
{
    class Program
    {
        static void Main(string[] args)
        {
           var oracle = new OracleConnection("Oracle DBMS");
           oracle.TimeOut = TimeSpan.FromMilliseconds(10000);

           var sql = new SqlConnection("SQL DBMS");
           sql.TimeOut = TimeSpan.FromMilliseconds(10000);

            /// Polymorphism at runtime can be different connection
            var command = new DbCommand("Running Oracle-SQL");
            command.Execute(oracle);
            
        }
    }
}
