using Common.Data;
using System.Threading;
using System.Threading.Tasks;
using WebApiApplication.Models.Conquests;
using WebApiApplication.Models.Prescriptions;

namespace WebApiApplication.Services.Conquest
{
    public interface IConquestControllerService
    {
        Task AddConquestAsync(AddConquestRequest request, CancellationToken cancellationToken);

        Task CompleteQuestAsync(CompleteQuestRequest request, CancellationToken cancellationToken);

        Task CompleteConquestAsync(CompleteConquestRequest request, CancellationToken cancellationToken);
        Task<QuestsResponse> GetQuestsAsync(QuestsRequest request, CancellationToken cancellationToken);
        Task<ConquestsResponse> GetConquestsAsync(ConquestsRequest request, CancellationToken cancellationToken);
    }
}