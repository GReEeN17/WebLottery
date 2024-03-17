namespace WebLottery.Infrastructure.Entities.Abstractions;

public interface IEntity
{
    Guid Id { get; set; }
    bool IsActive { get; set; }
    DateTime CreatedAt { get; set; }
    DateTime UpdatedAt { get; set; }
    int UserCreated { get; set; }
    int UserUpdated { get; set; }
}