using System;
using System.Threading;
using System.Threading.Tasks;
using Common.Database.Dto;

namespace Common.Database.DataAccess
{
    public interface IPatientDataAccess
    {
        Task<Patient> GetPatientByGuidAsync(Guid patientId, CancellationToken cancellationToken);
    }
}