using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WebApiApplication.Models.Patients;

namespace WebApiApplication.Services.Patients.Implementation
{
    internal class PatientsControllerService : IPatientsControllerService
    {
        public async Task<SearchPatientsResponse> SearchPatientsAsync(SearchPatientsRequest request, CancellationToken cancellationToken)
        {
            return new SearchPatientsResponse
            {
                PatientsItems = new List<SearchPatientsItem>
                {
                    new SearchPatientsItem
                    {
                        Guid = Guid.NewGuid(),
                        FirstName = request.FirstName,
                        LastName = request.LastName,
                        PersonalId = request.PersonalId,
                    }
                }
            };
        }
    }
}