using System;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Common.Database.DataAccess.Implementation.Context;
using Common.Database.Dto;

namespace Common.Database.DataAccess.Implementation
{
    public class PatientDataAccess : IPatientDataAccess, IDisposable
    {
        private readonly YourHelthContext _context;

        public PatientDataAccess()
        {
            _context = new YourHelthContext();
        }

        public Task<Patient> GetPatientByGuidAsync(Guid userId, CancellationToken cancellationToken)
        {
            return _context.Users.Where(user => user.Guid == userId).FirstOrDefaultAsync(cancellationToken);
        }

        public Task AddPatientAsync(Patient patient, CancellationToken cancellationToken)
        {
            _context.Users.Add(patient);
            return _context.SaveChangesAsync(cancellationToken);
        }

        void IDisposable.Dispose()
        {
            _context.Dispose();
        }
    }
}