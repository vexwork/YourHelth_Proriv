using Common.Database.Dto;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Database.DataAccess.Implementation.Context
{
    [DbConfigurationType(typeof(DbConfigurationProvider))]
    internal partial class YourHelthContext : DbContext
    {
        private const string ServerName = @"(localdb)\MSSQLLocalDB";
        private static string ConnectionString(string serverName) => $@"data source={serverName};initial catalog=YourHelthContext;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";
        
        public YourHelthContext(string serverName) : base(ConnectionString(serverName))
        {
        }

        public YourHelthContext() : this(ServerName)
        {
        }

        public DbSet<Patient> Patients { get; set; }

    }
}
