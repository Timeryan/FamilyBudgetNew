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
    public class UserRepository : IUserRepository
    {
        private readonly IRepository<UserEntity> _userRepository;

        public UserRepository(IRepository<UserEntity> userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<UserEntity> GetByIdAsync(int id, CancellationToken cancellation)
        {
            return _userRepository.FindAsync(id, cancellation);
        }

        public IQueryable<UserEntity> Where(Expression<Func<UserEntity, bool>> predicate)
        {
            return _userRepository.Where(predicate);
        }

        public async Task<int> AddAsync(UserEntity user, CancellationToken cancellation)
        {
            return await _userRepository.AddAsync(user, cancellation);
        }

        public async Task UpdateAsync(UserEntity user, CancellationToken cancellation)
        {
            await _userRepository.UpdateAsync(user, cancellation);
        }
    }
}