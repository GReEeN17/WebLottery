using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using WebLottery.Infrastructure.Entities.Abstractions;
using WebLottery.Infrastructure.Implementations.Abstractions;

namespace WebLottery.Infrastructure.Implementations.DataContext;

public class DbRepository(DataContext context) : IDbRepository
{
    public IQueryable<T> Get<T>() where T: class, IEntity
    {
        return context.Set<T>().Where(x=> x.IsActive).AsQueryable();
    }

    public IQueryable<T> Get<T>(Expression<Func<T, bool>> selector) where T : class, IEntity
    {
        return context.Set<T>().Where(selector).Where(x => x.IsActive).AsQueryable();
    }

    public async Task<T> Add<T>(T newEntity) where T: class, IEntity
    {
        var entity = await context.Set<T>().AddAsync(newEntity);
        return entity.Entity;
    }

    public async Task AddRange<T>(IEnumerable<T> newEntities) where T: class, IEntity
    {
        await context.Set<T>().AddRangeAsync(newEntities);
    }

    public async Task Delete<T>(Guid id) where T : class, IEntity
    {
        var activeEntity = await context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
        activeEntity.IsActive = false;
        await Task.Run(() => context.Update(activeEntity));
    }
    
    public async Task Remove<T>(T entity) where T: class, IEntity
    {
        await Task.Run(() => context.Set<T>().Remove(entity));
    }

    public async Task RemoveRange<T>(IEnumerable<T> entities) where T: class, IEntity
    {
        await Task.Run(() => context.Set<T>().RemoveRange(entities));
    }

    public async Task Update<T>(T entity) where T: class, IEntity
    {
        await Task.Run(() => context.Set<T>().Update(entity));
    }

    public async Task UpdateRange<T>(IEnumerable<T> entities) where T: class, IEntity
    {
        await Task.Run(() => context.Set<T>().UpdateRange(entities));
    }

    public async Task<int> SaveChangesAsync()
    {
        return await context.SaveChangesAsync();
    }

    public IQueryable<T> GetAll<T>() where T: class, IEntity
    {
        return context.Set<T>().AsQueryable();
    }
}