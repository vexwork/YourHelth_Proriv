using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using WebApiApplication.Models;
using WebApiApplication.Services;

namespace WebApiApplication.Controllers
{
    public class HomeController : ApiController
    {
        private readonly IHomeControllerService _homeControllerService;

        public HomeController(IHomeControllerService homeControllerService)
        {
            _homeControllerService = homeControllerService;
        }

        [HttpGet]
        [Route("v1/hello-world/")]
        public Task<HelloWorldResponse> HelloWorldAsync(string name, CancellationToken cancellationToken)
        {
            return _homeControllerService
                .GetHelloWorldAsync(cancellationToken);
        }
    }
}