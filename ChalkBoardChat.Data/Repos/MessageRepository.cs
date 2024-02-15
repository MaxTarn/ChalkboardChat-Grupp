using ChalkBoardChat.Data.Database;
using ChalkBoardChat.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ChalkBoardChat.Data.Repos
{
    public class MessageRepository
    {
        private readonly MessageDbContext context;

        public MessageRepository(MessageDbContext context)
        {
            this.context = context;
        }
        public async Task Add(MessageModel entity)
        {
            await context.AddAsync(entity);
        }

        public void Delete(MessageModel entity)
        {
            context.Messages.Remove(entity);
        }

        public async Task<MessageModel?> Get(int id)

        {
            return await context.Messages.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<MessageModel>> GetAll()
        {
            return await context.Messages.ToListAsync();
        }

        public async Task UpdateAsync(MessageModel entity)
        {
            MessageModel? messageModel = await Get(entity.Id);
            if (messageModel != null)
            {
                messageModel = entity;

            }

        }

        public async Task Save()
        {
            await context.SaveChangesAsync();
        }
    }
}
