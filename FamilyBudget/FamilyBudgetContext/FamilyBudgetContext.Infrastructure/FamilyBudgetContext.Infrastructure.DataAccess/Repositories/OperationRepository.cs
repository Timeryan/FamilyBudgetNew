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
    public class OperationRepository : IOperationRepository
    {
        private readonly IRepository<OperationEntity> _operationRepository;

        public OperationRepository(IRepository<OperationEntity> operationRepository)
        {
            _operationRepository = operationRepository;
        }

        public Task<OperationEntity> GetByIdAsync(int id, CancellationToken cancellation)
        {
            return _operationRepository.FindAsync(id, cancellation);
        }

        public IQueryable<OperationEntity> Where(Expression<Func<OperationEntity, bool>> predicate)
        {
            return _operationRepository.Where(predicate);
        }

        public async Task<int> AddAsync(OperationEntity operation, CancellationToken cancellation)
        {
            return await _operationRepository.AddAsync(operation, cancellation);
        }

        public async Task DeleteAsync(int id, CancellationToken cancellation)
        {
            await _operationRepository.DeleteAsync(id, false, cancellation);
        }

        public async Task UpdateAsync(OperationEntity operation, CancellationToken cancellation)
        {
            await _operationRepository.UpdateAsync(operation, cancellation);
        }
    }
}