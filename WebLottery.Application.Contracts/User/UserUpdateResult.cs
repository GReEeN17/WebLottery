namespace WebLottery.Application.Contracts.User;

public abstract record UserUpdateResult
{
    private UserUpdateResult() {}

    public sealed record Success : UserUpdateResult;

    public sealed record NotAuthorized : UserUpdateResult;
}