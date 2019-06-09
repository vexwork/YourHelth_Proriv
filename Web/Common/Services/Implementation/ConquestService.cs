using Common.Database.DataAccess;
using Common.Database.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Common.Services.Implementation
{
    internal class ConquestService : IConquestService
    {
        private readonly IYourHelthDataAccess _context;
        private readonly IPatientService _patientService;

        public ConquestService(IYourHelthDataAccess context, IPatientService patientService)
        {
            _context = context;
            _patientService = patientService;
        }

        public Task AddConquestAsync(Conquest conquest, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                try
                {
                    _context.Conquest.Add(conquest);
                    return _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw;
                }
            });
        }

        public Conquest BuildConquest(Patient patient, DateTime beginTime, string name, List<Prescription> prescriptions)
        {
            var quests = BuildQuests(beginTime, prescriptions);
            return new Conquest()
            {
                Name = name,
                Patient = patient,
                BeginTime = beginTime,
                Prescriptions = prescriptions,
                Quests = quests,
            };
        }

        private List<Quest> BuildQuests(DateTime beginTime, List<Prescription> prescriptions)
        {
            var quests = prescriptions.SelectMany(p => {
                var beginDay = beginTime.Date;
                var endDay = beginDay.AddDays(p.DurationInDays);

                var times = new List<DateTime>();
                for(var day = beginDay; day < endDay; day = day.AddDays(1))
                {
                    foreach(var timeOfDay in p.ActionTimes.Select(x => x.Time))
                    {
                        times.Add(day.Add(timeOfDay));
                    }
                }
                times.Sort();
                return times.Select(tm => {
                    return new Quest()
                    {
                        Prescription = p,
                        Time = tm,
                        State = Data.QuestState.Waiting,
                    };
                });
            });
            return quests.OrderBy(x => x.Time).ToList();
        }

    }
}
