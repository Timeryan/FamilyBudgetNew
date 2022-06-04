using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using FamilyBudgetContext.Domain.Domain;

namespace FamilyBudgetContext.Application.AppServices.Shared.Repositories
{
    public interface IOperationRepository
    {
        Task<OperationEntity> GetByIdAsync(int id, CancellationToken cancellation);
        IQueryable<OperationEntity> Where(Expression<Func<OperationEntity, bool>> predicate);
        Task<int> AddAsync(OperationEntity operation, CancellationToken cancellation);
        Task DeleteAsync(int id, CancellationToken cancellation);
        Task UpdateAsync(OperationEntity operation, CancellationToken cancellation);
    }
}
