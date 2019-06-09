using System.Threading;
using System.Threading.Tasks;
using WebApiApplication.Models.Prescriptions;

namespace WebApiApplication.Services.Conquest
{
    public interface IConquestControllerService
    {
        Task AddPrescriptionAsync(AddPrescriptionRequest request, CancellationToken cancellationToken);
    }
}