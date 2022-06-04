using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FamilyBudgetContext.Domain.Domain;

namespace FamilyBudgetContext.Application.AppServices.Shared.Repositories
{
    public interface IChatRepository
    {
        Task<IList<MessageEntity>> GetByRoomIdAsync(int roomId, CancellationToken cancellation);
        Task<int> AddAsync(MessageEntity message, CancellationToken cancellation);
    }
}
