using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using FamilyBudgetContext.Domain.Domain;

namespace FamilyBudgetContext.Application.AppServices.Shared.Repositories
{
    public interface IUserRepository
    {
        Task<UserEntity> GetByIdAsync(int id, CancellationToken cancellation);
        IQueryable<UserEntity> Where(Expression<Func<UserEntity, bool>> predicate);
        Task<int> AddAsync(UserEntity user, CancellationToken cancellation);
        Task UpdateAsync(UserEntity user, CancellationToken cancellation);
    }
}
