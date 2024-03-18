using WebLottery.Infrastructure.Entities.EntitiesExtensions;

namespace WebLottery.Application.Contracts.DbResponses;

public class CreateAdminDbResponse
{
    public string? Username { get; set; }
    public UserRole? UserRole { get; set; }
}