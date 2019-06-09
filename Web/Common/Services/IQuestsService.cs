using System;
using System.Threading;
using System.Threading.Tasks;
using Common.Data;
using Common.Database.Dto;

namespace Common.Services
{
    public interface IQuestsService
    {
        Task<Quest> GetQuestAsync(Guid guid, CancellationToken cancellationToken);

        Task CompleteQuestAsync(Guid guid, QuestState state, CancellationToken cancellationToken);

        Task<bool> IsQuestCanBeCompleted(Quest quest, CancellationToken cancellationToken);
    }
}