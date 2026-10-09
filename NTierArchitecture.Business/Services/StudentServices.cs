using System.Linq.Expressions;
using FluentValidation.Results;
using NTierArchitecture.Business.Abstraction;
using NTierArchitecture.Business.Validators;
using NTierArchitecture.DataAccsess.Repostories;
using NTierArchitecture.Domain.Entities;

namespace NTierArchitecture.Business.Services;

public class StudentServices(StudentRepostory studentRepostory) : IManager<Student>
{
    private readonly StudentRepostory _studentRepostory = studentRepostory;

    public void Create(Student entity)
    {
        if(IfEntityExists(entity))
            throw new Exception("Entity already exists.");

        ValidationResult result = new StudentValidator().Validate(entity);

        if (!result.IsValid)
            throw new Exception("Invalid entity.");
        _studentRepostory.Create(entity);
    }

    public void DeleteById(int id)
    {
        var cat = _studentRepostory.GetById(id);
        if (cat == null)
            throw new Exception("Entity not found.");
        _studentRepostory.DeleteById(id);
    }

    public IEnumerable<Student>? GetAll()
    {
        return _studentRepostory.GetAll() ?? throw new Exception("No entities found.");
    }

    public Student? GetById(int id)
    {
        return _studentRepostory.GetById(id);
    }

    public bool IfEntityExists(Student entity)
    {
        if (entity != null)
        {
            var existingEntity = entity!.ID!;
            return _studentRepostory.IfEntityExists(x => x.ID! == entity!.ID!);
                    
        }
        return false;
    }

    public void Update(Student entity)
    {
        ValidationResult result = new StudentValidator().Validate(entity);
        if (!result.IsValid)
            throw new Exception(string.Join("\n",result.Errors));
        if (entity != null)
            _studentRepostory.Update(entity);
    }
}
