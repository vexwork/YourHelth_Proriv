using Common.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using WebApiApplication.Models.Prescriptions;
using Common.Database.Dto;

namespace WebApiApplication.Services.Conquest.Implementation
{
    public class ConquestControllerService : IConquestControllerService
    {
        private readonly IConquestService _conquestService;
        private readonly IPatientService _patientService;

        public ConquestControllerService(IConquestService conquestService, IPatientService patientService)
        {
            _conquestService = conquestService;
            _patientService = patientService;
        }

        public async Task AddConquestAsync(AddConquestRequest request, CancellationToken cancellationToken)
        {
            var patient = await _patientService.GetPatientByGuidAsync(request.PatientId, cancellationToken);
            var conqest = new Common.Database.Dto.Conquest()
            {
                Name = request.Name,
                Patient = patient,
                Prescriptions = request.Prescriptions.Select(x => new Prescription()
                {
                    Name = x.Name,
                    Type = x.Type,
                    Duration = x.Duration,
                    ActionTimes = x.ActionTimes.Select(at => new ActionTime()
                    {
                        Time = at
                    }).ToList(),
                }).ToList(),
            };
            await _conquestService.AddConquestAsync(conqest, cancellationToken);
        }
    }
}