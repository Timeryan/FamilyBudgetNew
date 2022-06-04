using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Common.DataAccess.Repositories;
using FamilyBudgetContext.Application.AppServices.Shared.Repositories;
using FamilyBudgetContext.Domain.Domain;

namespace FamilyBudgetContext.Infrastructure.DataAccess.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly IRepository<RoomEntity> _roomRepository;

        public RoomRepository(IRepository<RoomEntity> roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public Task<RoomEntity> GetByIdAsync(int userId, CancellationToken cancellation)
        {
            return _roomRepository.FindAsync(userId, cancellation);
        }

        public IQueryable<RoomEntity> Where(Expression<Func<RoomEntity, bool>> predicate)
        {
            return _roomRepository.Where(predicate);
        }

        public async Task<int> AddAsync(RoomEntity room, CancellationToken cancellation)
        {
            return await _roomRepository.AddAsync(room, cancellation);
        }

        public async Task DeleteAsync(int id, CancellationToken cancellation)
        {
            await _roomRepository.DeleteAsync(id, false, cancellation);
        }

        public async Task UpdateAsync(RoomEntity room, CancellationToken cancellation)
        {
            await _roomRepository.UpdateAsync(room, cancellation);
        }
    }
}