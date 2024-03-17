namespace WebLottery.Infrastructure.Entities.Abstractions;

public abstract class Entity : IEntity
{
    public Guid Id { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}