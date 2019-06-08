using System;
using System.Threading;
using System.Threading.Tasks;
using Common.Database.DataAccess;
using WebApiApplication.Models;

namespace WebApiApplication.Services.Implementation
{
    internal class HomeControllerService : IHomeControllerService
    {
        private readonly IPatientDataAccess _userDataAccess;
        

        public HomeControllerService(IPatientDataAccess userDataAccess)
        {
            _userDataAccess = userDataAccess;
        }

        public async Task<HelloWorldResponse> GetHelloWorldAsync(CancellationToken cancellationToken)
        {
            var user = await _userDataAccess.GetPatientByGuidAsync(Guid.NewGuid(), cancellationToken);

            if (user == null)
            {
                return new HelloWorldResponse
                {
                    Message = "User not found",
                    Status = Status.Error,
                };
            }

            return new HelloWorldResponse
            {
                Message = $"Hello, world !!! And You {user.Name} : {user.Guid}",
                Status = Status.Ok,
            };
        }
    }
}