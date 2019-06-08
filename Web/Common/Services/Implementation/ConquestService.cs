using Common.Database.DataAccess;
using Common.Database.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Common.Services.Implementation
{
    internal class ConquestService : IConquestService
    {
        private readonly IYourHelthDataAccess _context;
        private readonly IPatientService _patientService;

        public ConquestService(IYourHelthDataAccess context, IPatientService patientService)
        {
            _context = context;
            _patientService = patientService;
        }

        public async Task AddPrescriptionAsync(Guid conquestId, Prescription prescription, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
