using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Common.DataAccess.Repositories;
using FamilyBudgetContext.Application.AppServices.Shared.Repositories;
using FamilyBudgetContext.Domain.Domain;

namespace FamilyBudgetContext.Infrastructure.DataAccess.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IRepository<CategoryEntity> _categoryRepository;

        public CategoryRepository(IRepository<CategoryEntity> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public Task<CategoryEntity> GetByIdAsync(int userId, CancellationToken cancellation)
        {
            return _categoryRepository.FindAsync(userId, cancellation);
        }

        public IQueryable<CategoryEntity> Where(Expression<Func<CategoryEntity, bool>> predicate)
        {
            return _categoryRepository.Where(predicate);
        }

        public async Task<int> AddAsync(CategoryEntity category, CancellationToken cancellation)
        {
            return await _categoryRepository.AddAsync(category, cancellation);
        }

        public async Task AddRangeAsync(IEnumerable<CategoryEntity> categories, CancellationToken cancellation)
        {
            await _categoryRepository.AddRangeAsync(categories, cancellation);
        }

        public async Task DeleteAsync(int id, CancellationToken cancellation)
        {
            await _categoryRepository.DeleteAsync(id, false, cancellation);
        }

        public async Task UpdateAsync(CategoryEntity category, CancellationToken cancellation)
        {
            await _categoryRepository.UpdateAsync(category, cancellation);
        }
    }
}