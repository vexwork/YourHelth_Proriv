using Common.Database.Dto;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Database.DataAccess.Implementation
{

    [DbConfigurationType(typeof(DbConfigurationProvider))]
    internal partial class YourHelthContext : DbContext, IYourHelthDataAccess
    {
#if SQLEXPRESS
        private const string ServerName = @"localhost\SQLEXPRESS";
#else
        private const string ServerName = @"DESKTOP-TAU7I9J";
#endif
        private static string ConnectionString(string serverName) => $@"data source={serverName};initial catalog=YourHelthContext;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";

        public YourHelthContext() : base(ConnectionString(ServerName))
        {
            Database.CommandTimeout = 10;
        }

        public DbSet<Patient> Patient { get; set; }
        public DbSet<Conquest> Conquest { get; set; }
        public DbSet<Quest> Quest { get; set; }
        public DbSet<Prescription> Prescription { get; set; }
        public DbSet<ActionTime> ActionTime { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>()
                .HasMany(c => c.Conquests)
                .WithRequired(o => o.Patient);
            modelBuilder.Entity<Conquest>()
                .HasMany(c => c.Quests)
                .WithRequired(o => o.Conquest);
        }
    }
}
