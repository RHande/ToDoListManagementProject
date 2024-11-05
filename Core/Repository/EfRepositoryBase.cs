using System.Linq.Expressions;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.Repository;

public abstract class EfRepositoryBase <TContext ,TEntity, TId> : IRepository<TEntity, TId>
    where TEntity : Entity<TId>, new()
    where TContext : DbContext
{
    private IRepository<TEntity, TId> _repositoryImplementation;
    protected TContext Context { get; }//Sadece miras aldığı sınıflar erişebilsin diye protected yaptık.
    
    public EfRepositoryBase(TContext context)
    {
        Context = context;
    }
    
    
    public TEntity Add(TEntity entity)
    {
        entity.CreatedTime = DateTime.Now;
        Context.Set<TEntity>().Add(entity);
        Context.SaveChanges();
        return entity;
    }

    public TEntity Update(TEntity entity)
    {
        entity.UpdatedTime = DateTime.Now;
        Context.Set<TEntity>().Update(entity);
        Context.SaveChanges();
        return entity;
    }

    public TEntity Delete(TEntity entity)
    {
        Context.Set<TEntity>().Remove(entity);
        Context.SaveChanges();
        return entity;
    }

    public TEntity? GetById(TId id)
    {
        return Context.Set<TEntity>().Find(id);
    }
    

    public List<TEntity> GetAll(Expression<Func<TEntity, bool>>? filter = null)
    {
        IQueryable<TEntity> query = Context.Set<TEntity>();
        if (filter is not null)
        {
            query = query.Where(filter);
        }
        return query.ToList();
    }
}