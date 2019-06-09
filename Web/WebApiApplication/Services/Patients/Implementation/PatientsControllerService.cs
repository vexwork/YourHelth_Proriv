using Common.Database.Dto;
using Common.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApiApplication.Models.Patients;

namespace WebApiApplication.Services.Patients.Implementation
{
    internal class PatientsControllerService : IPatientsControllerService
    {
        private readonly IPatientService _patientService;
        
        public PatientsControllerService(IPatientService patientService)
        {
            _patientService = patientService;
        }

        public async Task AddRandomPatientAsync(CancellationToken cancellationToken)
        {
            var rand = new Random();
            var chars = "qazwsxedcrfvtgbyhnujmikolp";
            string generateName()
            {
                return new string(Enumerable.Range(0, rand.Next(5) + 3).Select(x => chars[rand.Next(chars.Length - 1)]).ToArray());
            };
            await _patientService.AddPatientAsync(new Patient() { FirstName = generateName(), LastName = generateName(), PersonalId = Guid.NewGuid().ToString(), BirthDate = DateTime.Now }, cancellationToken);
        }

        public async Task<GetPatientResponse> GetPatientAsync(Guid guid, CancellationToken cancellationToken)
        {
            var patient = await _patientService.GetPatientByGuidAsync(guid, cancellationToken);
            if (patient == null)
                return new GetPatientResponse
                {
                    Patient = null,
                };

            return new GetPatientResponse
            {
                Patient = new PatientModel
                {
                    Guid = patient.Guid,
                    FirstName = patient.FirstName,
                    LastName = patient.LastName,
                    PersonalId = patient.PersonalId,
                    BithDate = patient.BirthDate,
                    MiddleName = patient.Patronymic,
                }
            };
        }

        public async Task<SearchPatientsResponse> SearchPatientsAsync(SearchPatientsRequest request, CancellationToken cancellationToken)
        {
            var patients = await _patientService.FindPatientsAsync(request.FirstName, request.LastName, request.PersonalId, cancellationToken);

            return new SearchPatientsResponse
            {
                PatientsItems = patients.Select(p => 
                {
                    return new PatientModel
                    {
                        Guid = p.Guid,
                        FirstName = p.FirstName,
                        LastName = p.LastName,
                        MiddleName = p.Patronymic,
                        PersonalId = p.PersonalId,
                        BithDate = p.BirthDate,
                    };
                }).ToList()
            };
        }
    }
}