using CleanArch.Application.Contracts;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Persistence.Repositories;

public class BaseRepository<T> : IAsyncRepository<T> where T : class
{
    protected readonly AppDbContext Context;

    public BaseRepository(AppDbContext context)
    {
        Context = context;
    }

    public async Task<T> GetByIdAsync(Guid id)
    {
        return (await Context.Set<T>().FindAsync(id))!;
    }

    public async Task<IReadOnlyList<T>> GetAllAsync()
    {
        return await Context.Set<T>().ToListAsync();
    }

    public async Task<T> AddAsync(T entity)
    {
        await Context.AddAsync(entity);
        await Context.SaveChangesAsync();
        return entity;
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await Context.Set<T>().FindAsync(id);

        if (entity != null)
        {
            Context.Set<T>().Remove(entity);
            await Context.SaveChangesAsync();
        }
    }

    public async Task<T> UpdateAsync(T entity)
    {
        Context.Entry(entity).State = EntityState.Modified;
        await Context.SaveChangesAsync();
        return entity;
    }
}