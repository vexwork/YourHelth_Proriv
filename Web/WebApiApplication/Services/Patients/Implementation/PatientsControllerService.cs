using Common.Database.DataAccess;
using Common.Database.Dto;
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
        private readonly IPatientDataAccess _userDataAccess;
        
        public PatientsControllerService(IPatientDataAccess userDataAccess)
        {
            _userDataAccess = userDataAccess;
        }

        public async Task AddRandomPatientAsync(CancellationToken cancellationToken)
        {
            var rand = new Random();
            var chars = "qazwsxedcrfvtgbyhnujmikolp";
            string generateName()
            {
                return new string(Enumerable.Range(0, rand.Next(5) + 3).Select(x => chars[rand.Next(chars.Length - 1)]).ToArray());
            };
            await _userDataAccess.AddPatientAsync(new Patient() { FirstName = generateName(), LastName = generateName(), PersonalId = Guid.NewGuid().ToString() }, cancellationToken);
        }

        public async Task<SearchPatientsResponse> SearchPatientsAsync(SearchPatientsRequest request, CancellationToken cancellationToken)
        {
            var patients = await _userDataAccess.FindPatientsAsync(request.FirstName, request.LastName, request.PersonalId, cancellationToken);

            return new SearchPatientsResponse
            {
                PatientsItems = patients.Select(p => 
                {
                    return new SearchPatientsItem
                    {
                        Guid = p.Guid,
                        FirstName = p.FirstName,
                        LastName = p.LastName,
                        PersonalId = p.PersonalId,
                    };
                }).ToList()
            };
        }
    }
}