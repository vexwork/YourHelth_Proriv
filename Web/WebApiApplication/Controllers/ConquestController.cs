using System.Web.Http;
using WebApiApplication.Services.Conquest;

namespace WebApiApplication.Controllers
{
    /// <summary>
    /// Контроллер для работы с предписаниями пациентов
    /// </summary>
    public class ConquestController : ApiController
    {
        private readonly IConquestControllerService _conquestControllerService;

        public ConquestController(IConquestControllerService conquestControllerService)
        {
            _conquestControllerService = conquestControllerService;
        }   
    }
}