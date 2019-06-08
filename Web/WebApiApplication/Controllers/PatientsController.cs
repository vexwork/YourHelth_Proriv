using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApiApplication.Models.Patients;
using WebApiApplication.Services.Patients;


namespace WebApiApplication.Controllers
{
    /// <summary>
    /// Контроллер для работы с пациентами 
    /// </summary>
    public class PatientsController : ApiController
    {
        private readonly IPatientsControllerService _patientsControllerService;

        public PatientsController(IPatientsControllerService patientsControllerService)
        {
            _patientsControllerService = patientsControllerService;
        }

        /// <summary>
        /// Ищет пациентов по заданным в запросе параметрам
        /// Если не найдено ни одного пациента удовлетворяющего условиям возвращается пустой список
        /// </summary>
        [HttpPost]
        [Route("v1/search-patients/")]
        public Task<SearchPatientsResponse> SearchPatientsAsync(SearchPatientsRequest request,
            CancellationToken cancellationToken)
        {
            return _patientsControllerService
                .SearchPatientsAsync(request, cancellationToken);
        }
    }
}