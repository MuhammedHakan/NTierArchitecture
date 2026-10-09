using NTierArchitecture.Domain.Entities;
using System.Linq.Expressions;

namespace NTierArchitecture.DataAccess.Abstractions;

public interface IRepository<T> where T : BaseEntity
{
    void Create(T entity);
    void Update(T entity);
    void DeleteById(int id);
    T? GetById(int id);
    IEnumerable<T>? GetAll();
    bool IfEntityExists(Expression<Func<T, bool>> filter);
}