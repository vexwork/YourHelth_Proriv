using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using WebApiApplication.Models.Patients;
using WebApiApplication.Services.Patients;


namespace WebApiApplication.Controllers
{
    public class PatientsController : ApiController
    {
        private readonly IPatientsControllerService _patientsControllerService;

        public PatientsController(IPatientsControllerService patientsControllerService)
        {
            _patientsControllerService = patientsControllerService;
        }

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