namespace WebLottery.Application.Contracts.User;

public abstract record UserLoginResult
{
    private UserLoginResult() {}

    public sealed record Success : UserLoginResult;

    public sealed record IncorrectPassword : UserLoginResult;

    public sealed record UserNotFound : UserLoginResult;
}