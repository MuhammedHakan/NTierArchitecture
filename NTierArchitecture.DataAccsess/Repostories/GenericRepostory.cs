
using Microsoft.EntityFrameworkCore;
using NTierArchitecture.DataAccess.Abstractions;
using NTierArchitecture.DataAccsess.Context;
using NTierArchitecture.Domain.Entities;
using System.Linq.Expressions;

namespace NTierArchitecture.DataAccsess.Repostories; 
public class GenericRepostory<T>(AppDbContext context) : IRepository<T> where T : BaseEntity
{
    protected readonly AppDbContext _context = context;
    private readonly DbSet<T> _dbSet = context.Set<T>();
    public void Create(T entity)
    {
        entity.IsActive = true;
        entity.CreateDate = DateTime.Now;
        _dbSet.Add(entity);
        _context.SaveChanges();
    }

    public void DeleteById(int id)
    {
        var entity = _dbSet.FirstOrDefault(x => x.ID == id);
        if (entity != null)
        {
            _dbSet.Remove(entity);
            _context.SaveChanges();
        }
    }

    public IEnumerable<T>? GetAll()
    {
        return [.. _dbSet];
    }

    public T? GetById(int id)
    {
        return _dbSet.FirstOrDefault(x => x.ID == id);
    }

    public bool IfEntityExists(Expression<Func<T, bool>> filter)
    {
        return _dbSet.Any(filter);
    }

    public void Update(T entity)
    {
        entity.UpdateDate = DateTime.Now;
        _dbSet.Update(entity);
        _context.SaveChanges();
    }
}
