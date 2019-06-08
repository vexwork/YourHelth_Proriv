using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using WebApiApplication.Models;

namespace WebApiApplication.Controllers
{
    public class HomeController : ApiController
    {
        [HttpGet]
        [Route("v1/hello-world/")]
        public async Task<HelloWorldResponse> HelloWorldAsync(string name, CancellationToken cancellationToken)
        {
            return new HelloWorldResponse
            {
                Message = $"Hello, world !!! And You {name}",
                Status = Status.Ok,
            };
        }
    }
}