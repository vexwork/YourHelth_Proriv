using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Common.Database.DataAccess;
using Common.Database.Dto;
using Common.Services;

namespace Common.Services.Implementation
{
    internal class PatientService : IPatientService
    {
        private readonly IYourHelthDataAccess _context;

        public PatientService(IYourHelthDataAccess context)
        {
            _context = context;
        }

        public Task<Patient> GetPatientByGuidAsync(Guid userId, CancellationToken cancellationToken)
        {
            return _context.Patient.Where(patient => patient.Guid == userId).FirstOrDefaultAsync(cancellationToken);
        }

        public Task AddPatientAsync(Patient patient, CancellationToken cancellationToken)
        {
            _context.Patient.Add(patient);
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
                _context.Patient.Remove(oldPatient);
                _context.Patient.Add(patient);
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
            var patients = _context.Patient.AsQueryable();
            if (name != null)
            {
                patients = patients.Where(p => p.FirstName == name);
            }

            if (surname != null)
            {
                patients = patients.Where(p => p.LastName == surname);
            }

            if (personalId != null)
            {
                patients = patients.Where(p => p.PersonalId == personalId);
            }

            return patients.ToListAsync(cancellationToken);
        }
    }
}