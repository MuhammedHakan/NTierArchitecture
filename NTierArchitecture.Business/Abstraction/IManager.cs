using NTierArchitecture.Domain.Entities;
using System.Xml.Serialization;

namespace NTierArchitecture.Business.Abstraction; 
internal interface IManager<T> where T : BaseEntity
{
    void Create(T entity);
    void Update(T entity);
    void DeleteById(int id);
    T? GetById(int id);
    IEnumerable<T>? GetAll();
    bool IfEntityExists(T entity);
}
