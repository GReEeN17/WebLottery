namespace Models.Abstractions;

public interface IEntity
{
    bool IsActive { get; set; }
    DateTime DateCreated { get; set; }
    DateTime DateUpdated { get; set; }
    Guid UserCreated { get; set; }
    Guid UserUpdated { get; set; }
}