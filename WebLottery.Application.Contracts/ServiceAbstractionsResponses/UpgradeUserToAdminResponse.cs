using WebLottery.Application.Contracts.ServiceAbstractionsResponsesAbstractions;
using WebLottery.Infrastructure.Entities.EntitiesExtensions;

namespace WebLottery.Application.Contracts.ServiceAbstractionsResponses;

public class UpgradeUserToAdminResponse : Response
{
    public UserRole? UserRole { get; set; }
}