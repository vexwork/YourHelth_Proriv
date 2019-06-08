using System;
using System.Threading;
using System.Threading.Tasks;
using WebApiApplication.Models.Patients;

namespace WebApiApplication.Services.Patients
{
    public interface IPatientsControllerService
    {
        Task<SearchPatientsResponse> SearchPatientsAsync(SearchPatientsRequest request, CancellationToken cancellationToken);
        Task AddRandomPatientAsync(CancellationToken cancellationToken);

        Task<GetPatientResponse> GetPatientAsync(Guid guid, CancellationToken cancellationToken);
    }
}