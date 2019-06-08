using System;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using WebApiApplication.Models;
using WebApiApplication.Services;
using WebApiApplication.Services.Logging;

namespace WebApiApplication.Controllers
{
    public class HomeController : ApiController
    {
        private readonly IHomeControllerService _homeControllerService;
        private readonly ILoggingService _loggingService;

        public HomeController(IHomeControllerService homeControllerService,
            ILoggingService loggingService)
        {
            _homeControllerService = homeControllerService;
            _loggingService = loggingService;
        }

        [HttpGet]
        [Route("v1/hello-world/")]
        public Task<HelloWorldResponse> HelloWorldAsync(string name, CancellationToken cancellationToken)
        {
            _loggingService.Trace($"Пользователь прислал {name}");
            _loggingService.LogError("Ошибка здаровнья с пользователем", new Exception("WHAT!"));
            return _homeControllerService
                .GetHelloWorldAsync(cancellationToken);
            
        }
    }
}