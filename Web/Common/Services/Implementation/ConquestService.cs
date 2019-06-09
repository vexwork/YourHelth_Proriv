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

        public Task AddConquestAsync(Conquest conquest, CancellationToken cancellationToken)
        {
            _context.Conquest.Add(conquest);
            return _context.SaveChangesAsync(cancellationToken);
        }
    }
}
