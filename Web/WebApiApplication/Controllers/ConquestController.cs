using System;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using WebApiApplication.Models.Conquests;
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

        /// <summary>
        /// Завершает квест проставляя статус выполнено/не выполнено
        /// </summary>
        [HttpPost]
        [Route("v1/complete-quest/")]
        public Task CompleteQuestAsync(CompleteQuestRequest request, CancellationToken cancellationToken)
        {
            return _conquestControllerService
                .CompleteQuestAsync(request, cancellationToken);
        }

        /// <summary>
        /// Завершает предписание врача, проставляя прогресс выполнения предписаний
        /// </summary>
        [HttpPost]
        [Route("v1/complete-conquest/")]
        public Task CompleteConquestAsync(CompleteConquestRequest request, CancellationToken cancellationToken)
        {
            return _conquestControllerService
                .CompleteConquestAsync(request, cancellationToken);
        }
    }
}