namespace WebLottery.Infrastructure.Entities.EntitiesExtensions;

public static class UserRoleExtension
{
    public static string GetUserRole(this UserRole userRole)
    {
        return userRole switch
        {
            UserRole.Player => "player",
            UserRole.Admin => "admin",
            _ => throw new ArgumentOutOfRangeException(nameof(userRole), userRole, null)
        };
    }
}