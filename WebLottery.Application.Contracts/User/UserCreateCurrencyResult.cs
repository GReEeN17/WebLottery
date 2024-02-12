namespace WebLottery.Application.Contracts.Users;

public abstract record UserCreateCurrencyResult
{
    private UserCreateCurrencyResult() {}

    public sealed record Success : UserCreateCurrencyResult;

    public sealed record NotAuthorized : UserCreateCurrencyResult;

    public sealed record NotEnoughRights : UserCreateCurrencyResult;
}