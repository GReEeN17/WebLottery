namespace WebLottery.Application.Contracts.User;

public abstract record UserCreatePrizeResult
{
    private UserCreatePrizeResult() {}

    public sealed record Success : UserCreatePrizeResult;

    public sealed record NotAuthorized : UserCreatePrizeResult;

    public sealed record NotEnoughRights : UserCreatePrizeResult;
}