using Common.Data;
using Common.Database.DataAccess;
using Common.Database.Dto;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public Task<List<Quest>> GetWaitingQuestsAsync(Patient patient, CancellationToken cancellationToken)
        {
            return GetQuestsAsync(patient,  QuestState.Waiting, cancellationToken);
        }

        public Task<List<Quest>> GetFailedQuestsAsync(Patient patient, CancellationToken cancellationToken)
        {
            return GetQuestsAsync(patient,  QuestState.Failed, cancellationToken);
        }

        public Task<List<Quest>> GetPassedQuestsAsync(Patient patient, CancellationToken cancellationToken)
        {
            return GetQuestsAsync(patient,  QuestState.Passed, cancellationToken);
        }

        public Task<List<Quest>> GetAllQuestsAsync(Patient patient, CancellationToken cancellationToken)
        {
            return GetQuestsAsync(patient,  null, cancellationToken);
        }

        public Task<List<Quest>> GetQuestsAsync(Patient patient, QuestState? state, CancellationToken cancellationToken)
        {
            var quests = _context.Quest.Where(x => x.Conquest.Patient.Guid == patient.Guid).AsQueryable();
            if(state != null)
            {
                quests = quests.Where(x => x.State == state);
            }
            return quests.OrderBy(x => x.Time).ToListAsync(cancellationToken);
        }
        

        public Task<List<Conquest>> GetConquestsAsync(Patient patient, CancellationToken cancellationToken)
        {
            return _context.Conquest.Where(x => x.Patient.Guid == patient.Guid).ToListAsync();
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

        public Conquest BuildConquest(Patient patient, DateTime beginTime, string name,
            List<Prescription> prescriptions)
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

        public async Task CompleteConquestAsync(Guid guid, int? completeRate, CancellationToken cancellationToken)
        {
            var conquest = await _context.Conquest
                .FirstOrDefaultAsync(x => x.Guid == guid, cancellationToken);

            if (conquest == null)
                throw new Exception("Конквест не найден");

            conquest.CompleteRate = completeRate;
            await _context
                .SaveChangesAsync(cancellationToken);
        }

        private List<Quest> BuildQuests(DateTime beginTime, List<Prescription> prescriptions)
        {
            var quests = prescriptions.SelectMany(p =>
            {
                var beginDay = beginTime.Date;
                var endDay = beginDay.AddDays(p.DurationInDays);

                var times = new List<DateTime>();
                for (var day = beginDay; day < endDay; day = day.AddDays(1))
                {
                    foreach (var timeOfDay in p.ActionTimes.Select(x => x.Time))
                    {
                        times.Add(day.Add(timeOfDay));
                    }
                }

                times.Sort();
                return times.Select(tm =>
                {
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