using System.Linq.Expressions;
using FluentValidation.Results;
using NTierArchitecture.Business.Abstraction;
using NTierArchitecture.Business.Validators;
using NTierArchitecture.DataAccsess.Repostories;
using NTierArchitecture.Domain.Entities;

namespace NTierArchitecture.Business.Services;

public class LessonServices(LessonRepostory lessonRepostory) : IManager<Lesson>
{
    private readonly LessonRepostory _lessonRepostory = lessonRepostory;

    public void Create(Lesson entity)
    {
        if (IfEntityExists(entity))
            throw new Exception("Entity already exists.");

        ValidationResult result = new LessonValidator().Validate(entity);

        if (!result.IsValid)
            throw new Exception("Invalid entity.");
        _lessonRepostory.Create(entity);
    }

    public void DeleteById(int id)
    {
        var cat = _lessonRepostory.GetById(id);
        if (cat == null)
            throw new Exception("Entity not found.");
        _lessonRepostory.DeleteById(id);
    }

    public IEnumerable<Lesson>? GetAll()
    {
        return _lessonRepostory.GetAll() ?? throw new Exception("No entities found.");
    }

    public Lesson? GetById(int id)
    {
        return _lessonRepostory.GetById(id);
    }

    public bool IfEntityExists(Lesson entity)
    {
        if (entity != null)
        {
            var existingEntity = entity!.ID!;
            return _lessonRepostory.IfEntityExists(x => x.ID! == entity!.ID!);

        }
        return false;
    }

    public void Update(Lesson entity)
    {
        ValidationResult result = new LessonValidator().Validate(entity);
        if (!result.IsValid)
            throw new Exception(string.Join("\n", result.Errors));
        if (entity != null)
            _lessonRepostory.Update(entity);
    }
}
