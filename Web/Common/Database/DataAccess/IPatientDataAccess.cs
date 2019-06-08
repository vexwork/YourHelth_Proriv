using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Common.Database.Dto;

namespace Common.Database.DataAccess
{
    public interface IPatientDataAccess
    {
        Task AddOrUpdatePatientAsync(Patient patient, CancellationToken cancellationToken);
        Task AddPatientAsync(Patient patient, CancellationToken cancellationToken);

        Task<List<Patient>> FindPatientsAsync(string name, string surname, string personalId,
            CancellationToken cancellationToken);

        Task<List<Patient>> FindPatientsByPersonalIdAsync(string personalId, CancellationToken cancellationToken);
        Task<Patient> GetPatientByGuidAsync(Guid userId, CancellationToken cancellationToken);
    }

    internal class PatientDataAccess : IPatientDataAccess
    {
        public Task AddOrUpdatePatientAsync(Patient patient, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task AddPatientAsync(Patient patient, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<List<Patient>> FindPatientsAsync(string name, string surname, string personalId,
            CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<List<Patient>> FindPatientsByPersonalIdAsync(string personalId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Patient> GetPatientByGuidAsync(Guid userId, CancellationToken cancellationToken)
        {
            return Task.FromResult(
                new Patient());
        }
    }
}