using System;
using System.Data.Entity;
using System.Threading;
using System.Threading.Tasks;
using Common.Data;
using Common.Database.DataAccess;
using Common.Database.Dto;

namespace Common.Services.Implementation
{
    internal class QuestsService : IQuestsService
    {
        private readonly IYourHelthDataAccess _context;

        public QuestsService(IYourHelthDataAccess context)
        {
            _context = context;
        }


        public Task<Quest> GetQuestAsync(Guid guid, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task CompleteQuestAsync(Guid guid, QuestState state, CancellationToken cancellationToken)
        {
            var quest = await _context.Quest.FirstOrDefaultAsync(x => x.Guid == guid, cancellationToken);

            if (quest == null)
                throw new Exception("Квест не найден");

            quest.State = state;

            await _context.SaveChangesAsync(cancellationToken);

        }

        public Task<bool> IsQuestCanBeCompleted(Quest quest, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}