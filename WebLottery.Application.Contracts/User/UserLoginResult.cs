namespace WebLottery.Application.Contracts.Users;

public abstract record UserLoginResult
{
    private UserLoginResult() {}

    public sealed record Success : UserLoginResult;

    public sealed record IncorrectPassword : UserLoginResult;

    public sealed record UserNotFound : UserLoginResult;
}