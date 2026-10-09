using System.Linq.Expressions;
using FluentValidation.Results;
using NTierArchitecture.Business.Abstraction;
using NTierArchitecture.Business.Validators;
using NTierArchitecture.DataAccsess.Repostories;
using NTierArchitecture.Domain.Entities;

namespace NTierArchitecture.Business.Services;

public class ClassServices(ClassRepostory classRepostory) : IManager<Class>
{
    private readonly ClassRepostory _classRepostory = classRepostory;

    public void Create(Class entity)
    {
        if (IfEntityExists(entity))
            throw new Exception("Entity already exists.");

        ValidationResult result = new ClassValidator().Validate(entity);

        if (!result.IsValid)
            throw new Exception("Invalid entity.");
        _classRepostory.Create(entity);
    }

    public void DeleteById(int id)
    {
        var cat = _classRepostory.GetById(id);
        if (cat == null)
            throw new Exception("Entity not found.");
        _classRepostory.DeleteById(id);
    }

    public IEnumerable<Class>? GetAll()
    {
        return _classRepostory.GetAll() ?? throw new Exception("No entities found.");
    }

    public Class? GetById(int id)
    {
        return _classRepostory.GetById(id);
    }

    public bool IfEntityExists(Class entity)
    {
        if (entity != null)
        {
            var existingEntity = entity!.ID!;
            return _classRepostory.IfEntityExists(x => x.ID! == entity!.ID!);

        }
        return false;
    }

    public void Update(Class entity)
    {
        ValidationResult result = new ClassValidator().Validate(entity);
        if (!result.IsValid)
            throw new Exception(string.Join("\n", result.Errors));
        if (entity != null)
            _classRepostory.Update(entity);
    }
}
