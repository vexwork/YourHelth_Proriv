using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Common.Database.Dto;
using Common.Services;
using WebApiApplication.Models.Accounts;

namespace WebApiApplication.Services.Accounts.Implementation
{
    internal class AccountsControllerService : IAccountsControllerService
    {
        private readonly IPatientService _patientService;

        public AccountsControllerService(IPatientService patientService)
        {
            _patientService = patientService;
        }

        public async Task<RegisterPatientResponse> RegisterPatientAsync(RegisterPatientRequest data,
            CancellationToken cancellationToken)
        {
            var existedUsers = await _patientService.FindPatientsByPersonalIdAsync(data.PersonalId, cancellationToken);
            if (existedUsers.Any())
            {
                return RegisterPatientResponse.PersonalIdAlreadyExists;
            }

            var patient = new Patient
            {
                FirstName = data.FirstName,
                Patronymic = data.MiddleName,
                LastName = data.LastName,
                PersonalId = data.PersonalId,
                BirthDate = data.BirthDate,
            };

            await _patientService.AddPatientAsync(patient, cancellationToken);

            return new RegisterPatientResponse
            {
                Guid = patient.Guid,
                Status = RegisterPatientStatus.Ok,
            };
        }
    }
}