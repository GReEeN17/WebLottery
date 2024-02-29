using EntityFrameworkCore.Triggered;
using WebLottery.Infrastructure.Entities.Abstractions;

namespace WebLottery.Infrastructure.Implementations.Abstractions;

public class EntityTrigger : IBeforeSaveTrigger<Entity>
{
    public Task BeforeSave(ITriggerContext<Entity> context, CancellationToken cancellationToken)
    {
        if (context.ChangeType is ChangeType.Added)
        {
            context.Entity.UserCreated = 0;
            context.Entity.UserUpdated = 0;
            context.Entity.CreatedAt = DateTime.Now;
            context.Entity.UpdatedAt = DateTime.Now;
            context.Entity.IsActive = true;
        }

        if (context.ChangeType is ChangeType.Modified)
        {
            context.Entity.UserUpdated = 0;
            context.Entity.UpdatedAt = DateTime.Now;
        }
        
        return Task.CompletedTask;
    }
}