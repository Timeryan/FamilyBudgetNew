using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Common.DataAccess.Repositories;
using FamilyBudgetContext.Application.AppServices.Shared.Repositories;
using FamilyBudgetContext.Contracts.Shared.Contracts.Enums;
using FamilyBudgetContext.Domain.Domain;

namespace FamilyBudgetContext.Infrastructure.DataAccess.Repositories
{
    public class RoomToUserRepository : IRoomToUserRepository
    {
        private readonly IRepository<RoomToUserEntity> _roomToUserRepository;

        public RoomToUserRepository(IRepository<RoomToUserEntity> roomToUserRepository)
        {
            _roomToUserRepository = roomToUserRepository;
        }
        
        public async Task AddUserToRoomAsync(int roomId, int userId, UserRoleInRoomEnum role, string color, CancellationToken cancellation)
        {
            await _roomToUserRepository.AddAsync(
                new RoomToUserEntity
                {
                    RoomId = roomId,
                    UserId = userId,
                    Role = role,
                    UserColor = color
                }, cancellation);
        }

        public async Task DeleteUserFromRoomAsync(int roomId, int userId, CancellationToken cancellation)
        {
            var roomToUserEntity = _roomToUserRepository.Where(x => x.RoomId == roomId && x.UserId == userId).FirstOrDefault();
            if (roomToUserEntity != null)
                await _roomToUserRepository.DeleteAsync(roomToUserEntity.Id, false, cancellation);
        }

        public async Task UpdateUserRoleInRoomAsync(int roomId, int userId, UserRoleInRoomEnum role, CancellationToken cancellation)
        {
            var roomToUserEntity = _roomToUserRepository.Where(x => x.RoomId == roomId && x.UserId == userId).FirstOrDefault();
            if (roomToUserEntity != null)
            {
                roomToUserEntity.Role = role;
                await _roomToUserRepository.UpdateAsync(roomToUserEntity, cancellation);
            } 
        }
    }
}