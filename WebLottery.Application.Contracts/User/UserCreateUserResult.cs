namespace WebLottery.Application.Contracts.User;

public record UserCreateUserResult
{
    private UserCreateUserResult() {}

    public sealed record Success : UserCreateUserResult;

    public sealed record NotEnoughRights : UserCreateUserResult;

    public sealed record NotAuthorized : UserCreateUserResult;
}