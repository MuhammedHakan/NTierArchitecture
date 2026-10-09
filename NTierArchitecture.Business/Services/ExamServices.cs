using System.Linq.Expressions;
using FluentValidation.Results;
using NTierArchitecture.Business.Abstraction;
using NTierArchitecture.Business.Validators;
using NTierArchitecture.DataAccsess.Repostories;
using NTierArchitecture.Domain.Entities;

namespace NTierArchitecture.Business.Services;

public class ExamServices(ExamRepostory examRepostory) : IManager<Exam>
{
    private readonly ExamRepostory _examRepostory = examRepostory;

    public void Create(Exam entity)
    {
        if (IfEntityExists(entity))
            throw new Exception("Entity already exists.");

        ValidationResult result = new ExamValidator().Validate(entity);

        if (!result.IsValid)
            throw new Exception("Invalid entity.");
        _examRepostory.Create(entity);
    }

    public void DeleteById(int id)
    {
        var cat = _examRepostory.GetById(id);
        if (cat == null)
            throw new Exception("Entity not found.");
        _examRepostory.DeleteById(id);
    }

    public IEnumerable<Exam>? GetAll()
    {
        return _examRepostory.GetAll() ?? throw new Exception("No entities found.");
    }

    public Exam? GetById(int id)
    {
        return _examRepostory.GetById(id);
    }

    public bool IfEntityExists(Exam entity)
    {
        if (entity != null)
        {
            var existingEntity = entity!.ID!;
            return _examRepostory.IfEntityExists(x => x.ID! == entity!.ID!);

        }
        return false;
    }

    public void Update(Exam entity)
    {
        ValidationResult result = new ExamValidator().Validate(entity);
        if (!result.IsValid)
            throw new Exception(string.Join("\n", result.Errors));
        if (entity != null)
            _examRepostory.Update(entity);
    }
}
