namespace Models.Abstractions;

public class Entity : IEntity
{
    public bool IsActive { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime DateUpdated { get; set; }
    public Guid UserCreated { get; set; }
    public Guid UserUpdated { get; set; }
}