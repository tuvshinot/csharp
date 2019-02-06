using System;
using System.Threading;

namespace InterfaceAndExtend
{
    public class DbMigrator
    {
        private readonly ILogger _logger;

        public DbMigrator(ILogger logger)
        {
            this._logger = logger;
        }

        public void Migrate()
        {
            _logger.LogInfo("Migration Started " + DateTime.Now);
            // Database things 
            Thread.Sleep(1000);
            _logger.LogInfo("Migration finished " + DateTime.Now);

        }
    }
}