using System.Threading;
using System.Threading.Tasks;
using WebApiApplication.Models;

namespace WebApiApplication.Services
{
    public interface IHomeControllerService
    {
        Task<HelloWorldResponse> GetHelloWorldAsync(CancellationToken cancellationToken);
    }
}