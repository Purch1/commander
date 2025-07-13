namespace Commander.Application.Shared.Interfaces;

    public interface IGenericRepository<T> where T : class
    {
        Task<T> FindByIdAsync(int id);
        Task<IEnumerable<T>> FindAllAsync();
        Task SaveChangesAsync();
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
