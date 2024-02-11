namespace WebLottery.Application.Contracts.Users;

public record UserCreateUserResult
{
    private UserCreateUserResult() {}

    public sealed record Success : UserCreateUserResult;

    public sealed record NotEnoughRights : UserCreateUserResult;

    public sealed record NotAuthorized : UserCreateUserResult;
}