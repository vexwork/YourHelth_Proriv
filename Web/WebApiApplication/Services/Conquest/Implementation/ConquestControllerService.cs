using Common.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using WebApiApplication.Models.Prescriptions;

namespace WebApiApplication.Services.Conquest.Implementation
{
    public class ConquestControllerService
    {
        private readonly IConquestService _conquestService;

        public ConquestControllerService(IConquestService conquestService)
        {
            _conquestService = conquestService;
        }

        public Task AddPrescriptionAsync(AddPrescriptionRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}