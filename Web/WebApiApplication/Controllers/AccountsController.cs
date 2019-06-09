using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using WebApiApplication.Models.Accounts;
using WebApiApplication.Services.Accounts;

namespace WebApiApplication.Controllers
{
    /// <summary>
    /// Контроллер работы с аккаунтами пользователей в системе
    /// </summary>
    public class AccountsController : ApiController
    {
        private readonly IAccountsControllerService _accountsControllerService;

        public AccountsController(IAccountsControllerService accountsControllerService)
        {
            _accountsControllerService = accountsControllerService;
        }

        /// <summary>
        /// Регистрирует нового пациента
        /// </summary>
        [HttpPost]
        [Route("v1/register-patient/")]
        public Task<RegisterPatientResponse> RegisterPatientAsync(RegisterPatientRequest request,
            CancellationToken cancellationToken)
        {
            return _accountsControllerService
                .RegisterPatientAsync(request, cancellationToken);
        }
    }
}