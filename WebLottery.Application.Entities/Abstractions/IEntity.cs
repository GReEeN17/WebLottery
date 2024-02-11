namespace Models.Abstractions;

public interface IEntity
{
    int Id { get; set; }
    bool IsActive { get; set; }
    DateTime DateCreated { get; set; }
    DateTime DateUpdated { get; set; }
    Guid UserCreated { get; set; }
    Guid UserUpdated { get; set; }
}