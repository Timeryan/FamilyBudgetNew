using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using FamilyBudgetContext.Domain.Domain;

namespace FamilyBudgetContext.Application.AppServices.Shared.Repositories
{
    public interface IRoomRepository
    {
        Task<RoomEntity> GetByIdAsync(int id, CancellationToken cancellation);
        IQueryable<RoomEntity> Where(Expression<Func<RoomEntity, bool>> predicate);
        Task<int> AddAsync(RoomEntity room, CancellationToken cancellation);
        Task DeleteAsync(int id, CancellationToken cancellation);
        Task UpdateAsync(RoomEntity room, CancellationToken cancellation);
    }
}
