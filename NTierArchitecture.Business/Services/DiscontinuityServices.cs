using System.Linq.Expressions;
using FluentValidation.Results;
using NTierArchitecture.Business.Abstraction;
using NTierArchitecture.Business.Validators;
using NTierArchitecture.DataAccsess.Repostories;
using NTierArchitecture.Domain.Entities;

namespace NTierArchitecture.Business.Services;

public class DiscontinuityServices(DiscontinuityRepostory discontinuityRepostory) : IManager<Discontinuity>
{
    private readonly DiscontinuityRepostory _discontinuityRepostory = discontinuityRepostory;

    public void Create(Discontinuity entity)
    {
        if (IfEntityExists(entity))
            throw new Exception("Entity already exists.");

        ValidationResult result = new DiscontinuityValidator().Validate(entity);

        if (!result.IsValid)
            throw new Exception("Invalid entity.");
        _discontinuityRepostory.Create(entity);
    }

    public void DeleteById(int id)
    {
        var cat = _discontinuityRepostory.GetById(id);
        if (cat == null)
            throw new Exception("Entity not found.");
        _discontinuityRepostory.DeleteById(id);
    }

    public IEnumerable<Discontinuity>? GetAll()
    {
        return _discontinuityRepostory.GetAll() ?? throw new Exception("No entities found.");
    }

    public Discontinuity? GetById(int id)
    {
        return _discontinuityRepostory.GetById(id);
    }

    public bool IfEntityExists(Discontinuity entity)
    {
        if (entity != null)
        {
            var existingEntity = entity!.ID!;
            return _discontinuityRepostory.IfEntityExists(x => x.ID! == entity!.ID!);

        }
        return false;
    }

    public void Update(Discontinuity entity)
    {
        ValidationResult result = new DiscontinuityValidator().Validate(entity);
        if (!result.IsValid)
            throw new Exception(string.Join("\n", result.Errors));
        if (entity != null)
            _discontinuityRepostory.Update(entity);
    }
}
