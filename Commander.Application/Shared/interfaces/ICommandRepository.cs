using Commander.Application.Shared.Interfaces;

namespace Commander.Domain.Models
{
    public interface ICommandRepository : IGenericRepository<Command>
    {
        Task<bool> IsTitleUniqueAsync(string title);
        Task<Command> GetCommandWithDetailsAsync(int id);
        Task<Command> InsertAsync(Command command);
    }
}