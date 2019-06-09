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

        public async Task AddPrescriptionAsync(Guid patient, Prescription prescription, CancellationToken cancellationToken)
        {
            //todo на основании чего-то создать/открыть конквест
            //todo в конквест добавить назначение
        }
    }
}
