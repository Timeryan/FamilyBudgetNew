using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using FamilyBudgetContext.Domain.Domain;

namespace FamilyBudgetContext.Application.AppServices.Shared.Repositories
{
    public interface ICategoryRepository
    {
        Task<CategoryEntity> GetByIdAsync(int id, CancellationToken cancellation);
        IQueryable<CategoryEntity> Where(Expression<Func<CategoryEntity, bool>> predicate);
        Task<int> AddAsync(CategoryEntity category, CancellationToken cancellation);
        Task AddRangeAsync(IEnumerable<CategoryEntity> categories, CancellationToken cancellation);
        Task DeleteAsync(int id, CancellationToken cancellation);
        Task UpdateAsync(CategoryEntity category, CancellationToken cancellation);
    }
}
