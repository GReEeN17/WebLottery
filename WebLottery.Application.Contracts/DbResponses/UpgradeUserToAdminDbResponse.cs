using WebLottery.Infrastructure.Entities.EntitiesExtensions;

namespace WebLottery.Application.Contracts.DbResponses;

public class UpgradeUserToAdminDbResponse
{
    public string? Username { get; set; }
    public UserRole? UserRole { get; set; }
}