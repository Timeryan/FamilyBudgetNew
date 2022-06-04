using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Common.DataAccess.Repositories;
using FamilyBudgetContext.Application.AppServices.Shared.Repositories;
using FamilyBudgetContext.Domain.Domain;
using Microsoft.EntityFrameworkCore;

namespace FamilyBudgetContext.Infrastructure.DataAccess.Repositories
{
    public class ChatRepository : IChatRepository
    {
        private readonly IRepository<MessageEntity> _messageRepository;

        public ChatRepository(IRepository<MessageEntity> messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public async Task<IList<MessageEntity>> GetByRoomIdAsync(int roomId, CancellationToken cancellation)
        {
          return await _messageRepository.Where(x => x.RoomId == roomId).ToListAsync(cancellation);
        }

        public async Task<int> AddAsync(MessageEntity message, CancellationToken cancellation)
        {
            return await _messageRepository.AddAsync(message, cancellation);
        }
    }
}