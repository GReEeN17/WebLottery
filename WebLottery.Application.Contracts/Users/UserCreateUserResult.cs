namespace WebLottery.Application.Contracts.Users;

public record UserCreateUserResult
{
    private UserCreateUserResult() {}

    public sealed record Success : UserCreateUserResult;
}