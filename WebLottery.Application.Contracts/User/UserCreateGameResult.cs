namespace WebLottery.Application.Contracts.User;

public record UserCreateGameResult
{
    private UserCreateGameResult() {}

    public sealed record Success : UserCreateGameResult;

    public sealed record NotEnoughMoney : UserCreateGameResult;

    public sealed record NotAuthorized : UserCreateGameResult;
}