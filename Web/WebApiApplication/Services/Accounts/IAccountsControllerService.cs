using System.Threading;
using System.Threading.Tasks;
using WebApiApplication.Models.Accounts;

namespace WebApiApplication.Services.Accounts
{
    public interface IAccountsControllerService
    {
        Task<RegisterPatientResponse> RegisterPatientAsync(RegisterPatientRequest data,
            CancellationToken cancellationToken);
    }
}