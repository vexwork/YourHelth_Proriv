using Common.Database.Dto;
using System.Data.Entity;
using System.Threading;
using System.Threading.Tasks;

namespace Common.Database.DataAccess
{
    interface IYourHelthDataAccess
    {
        DbSet<Conquest> Conquest { get; }
        DbSet<Patient> Patient { get; }
        DbSet<Prescription> Prescription { get; }
        DbSet<Quest> Quest { get; }
        DbSet<ActionTime> ActionTime { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        int SaveChanges();
    }
}
