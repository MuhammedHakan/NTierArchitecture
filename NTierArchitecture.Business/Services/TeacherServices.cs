using System.Linq.Expressions;
using FluentValidation.Results;
using NTierArchitecture.Business.Abstraction;
using NTierArchitecture.Business.Validators;
using NTierArchitecture.DataAccsess.Repostories;
using NTierArchitecture.Domain.Entities;

namespace NTierArchitecture.Business.Services;

public class TeacherServices(TeacherRepostory teacherRepostory) : IManager<Teacher>
{
    private readonly TeacherRepostory _teacherRepostory = teacherRepostory;

    public void Create(Teacher entity)
    {
        if (IfEntityExists(entity))
            throw new Exception("Entity already exists.");

        ValidationResult result = new TeacherValidator().Validate(entity);

        if (!result.IsValid)
            throw new Exception("Invalid entity.");
        _teacherRepostory.Create(entity);
    }

    public void DeleteById(int id)
    {
        var cat = _teacherRepostory.GetById(id);
        if (cat == null)
            throw new Exception("Entity not found.");
        _teacherRepostory.DeleteById(id);
    }

    public IEnumerable<Teacher>? GetAll()
    {
        return _teacherRepostory.GetAll() ?? throw new Exception("No entities found.");
    }

    public Teacher? GetById(int id)
    {
        return _teacherRepostory.GetById(id);
    }

    public bool IfEntityExists(Teacher entity)
    {
        if (entity != null)
        {
            var existingEntity = entity!.ID!;
            return _teacherRepostory.IfEntityExists(x => x.ID! == entity!.ID!);

        }
        return false;
    }

    public void Update(Teacher entity)
    {
        ValidationResult result = new TeacherValidator().Validate(entity);
        if (!result.IsValid)
            throw new Exception(string.Join("\n", result.Errors));
        if (entity != null)
            _teacherRepostory.Update(entity);
    }
}
