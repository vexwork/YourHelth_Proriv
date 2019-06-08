
using Common.Database.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Common.Services
{
    public interface IConquestService
    {
        Task AddPrescriptionAsync(Guid patientId, Prescription prescription, CancellationToken cancellationToken);
    }
}
