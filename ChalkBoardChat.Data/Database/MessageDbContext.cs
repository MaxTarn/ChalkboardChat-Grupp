using ChalkBoardChat.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ChalkBoardChat.Data.Database
{
    public class MessageDbContext : DbContext
    {
        public MessageDbContext(DbContextOptions<MessageDbContext> options) : base(options) { }

        public DbSet<MessageModel> Messages { get; set; }
    }
}
