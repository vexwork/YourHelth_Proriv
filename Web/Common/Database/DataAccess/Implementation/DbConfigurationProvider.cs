using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.SqlServer;
using System.IO;

namespace Common.Database.DataAccess.Implementation
{
    internal sealed class DbConfigurationProvider : DbConfiguration
    {
        public DbConfigurationProvider()
        {
            SetDefaultConnectionFactory(new SqlConnectionFactory());
            SetProviderServices(SqlProviderServices.ProviderInvariantName, SqlProviderServices.Instance);

            //var path = Path.GetDirectoryName(GetType().Assembly.Location);
            //SetModelStore(new DefaultDbModelStore(path));
        }
    }
}
