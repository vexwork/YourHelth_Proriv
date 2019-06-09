﻿using Common.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using WebApiApplication.Models.Prescriptions;
using Common.Database.Dto;

namespace WebApiApplication.Services.Conquest.Implementation
{
    public class ConquestControllerService : IConquestControllerService
    {
        private readonly IConquestService _conquestService;
        private readonly IPatientService _patientService;

        public ConquestControllerService(IConquestService conquestService, IPatientService patientService)
        {
            _conquestService = conquestService;
            _patientService = patientService;
        }

        public async Task AddConquestAsync(AddConquestRequest request, CancellationToken cancellationToken)
        {
            var patient = await _patientService.GetPatientByGuidAsync(request.PatientId, cancellationToken);
            var conquest = _conquestService.BuildConquest(patient, request.BeginTime, request.Name, request.Prescriptions.Select(x => new Prescription()
            {
                Name = x.Name,
                Type = x.Type,
                DurationInDays = x.DurationInDays,
                ActionTimes = x.ActionTimes.Select(at => new ActionTime()
                {
                    Time = at
                }).ToList(),
            }).ToList());
            await _conquestService.AddConquestAsync(conquest, cancellationToken);
        }
    }
}