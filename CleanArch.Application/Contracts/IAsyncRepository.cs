namespace CleanArch.Application.Contracts;

public interface IAsyncRepository<T> where T : class
{
    Task<T> GetByIdAsync(Guid id);
    Task<IReadOnlyList<T>> GetAllAsync();
    Task<T> AddAsync(T entity);
    Task DeleteAsync(Guid id);
    Task<T> UpdateAsync(T entity);
}