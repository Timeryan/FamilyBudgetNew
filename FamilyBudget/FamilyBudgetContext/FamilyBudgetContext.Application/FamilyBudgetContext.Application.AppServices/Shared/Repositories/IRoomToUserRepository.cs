using System.Threading;
using System.Threading.Tasks;
using FamilyBudgetContext.Contracts.Shared.Contracts.Enums;

namespace FamilyBudgetContext.Application.AppServices.Shared.Repositories
{
    public interface IRoomToUserRepository
    {
        Task AddUserToRoomAsync(int roomId, int userId, UserRoleInRoomEnum role, string color, CancellationToken cancellation);
        Task DeleteUserFromRoomAsync(int roomId, int userId, CancellationToken cancellation);
        Task UpdateUserRoleInRoomAsync(int roomId, int userId, UserRoleInRoomEnum role, CancellationToken cancellation);
    }
}
