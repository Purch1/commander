using Commander.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Commander.Infrastructure.Data
{
    public class CommanderContext : DbContext
    {
        public CommanderContext(DbContextOptions<CommanderContext> options)
            : base(options)
        {
        }

        public DbSet<Command> Commands { get; set; }
    }
}
