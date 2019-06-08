using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Common.Database.DataAccess.Implementation.Context;
using Common.Database.Dto;

namespace Common.Database.DataAccess.Implementation
{
    internal class PatientDataAccess : IPatientDataAccess, IDisposable
    {
        private readonly YourHelthContext _context;

        public PatientDataAccess()
        {
            _context = new YourHelthContext();
        }

        public Task<Patient> GetPatientByGuidAsync(Guid userId, CancellationToken cancellationToken)
        {
            return _context.Patients.Where(patient => patient.Guid == userId).FirstOrDefaultAsync(cancellationToken);
        }

        public Task AddPatientAsync(Patient patient, CancellationToken cancellationToken)
        {
            _context.Patients.Add(patient);
            return _context.SaveChangesAsync(cancellationToken);
        }

        public async Task AddOrUpdatePatientAsync(Patient patient, CancellationToken cancellationToken)
        {
            var oldPatient = await GetPatientByGuidAsync(patient.Guid, cancellationToken);
            if (oldPatient == null)
            {
                await AddPatientAsync(patient, cancellationToken);
            }
            else
            {
                _context.Patients.Remove(oldPatient);
                _context.Patients.Add(patient);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }

        public Task<List<Patient>> FindPatientsByPersonalIdAsync(string personalId, CancellationToken cancellationToken)
        {
            return FindPatientsAsync(null, null, personalId, cancellationToken);
        }

        public Task<List<Patient>> FindPatientsAsync(string name, string surname, string personalId,
            CancellationToken cancellationToken)
        {
            var patients = _context.Patients.AsQueryable();
            if (name != null)
            {
                patients = patients.Where(p => p.Name == name);
            }

            if (surname != null)
            {
                patients = patients.Where(p => p.Surname == surname);
            }

            if (personalId != null)
            {
                patients = patients.Where(p => p.PersonalId == personalId);
            }

            return patients.ToListAsync(cancellationToken);
        }

        void IDisposable.Dispose()
        {
            _context.Dispose();
        }
    }
}