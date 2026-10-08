namespace NTierArchitecture.Domain.Entities;

public abstract class BaseEntity
{
    public int ID { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime UpdateDate { get; set; }
    public bool IsActive { get; set; }
}
