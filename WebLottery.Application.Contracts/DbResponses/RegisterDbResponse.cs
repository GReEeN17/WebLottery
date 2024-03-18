using WebLottery.Infrastructure.Entities.EntitiesExtensions;

namespace WebLottery.Application.Contracts.DbResponses;

public class RegisterDbResponse
{
    public string? Username { get; set; }
    public UserRole UserRole { get; set; }
}