namespace WebLottery.Application.Contracts.Users;

public record UserCreateGameResult
{
    private UserCreateGameResult() {}

    public sealed record Success : UserCreateGameResult;

    public sealed record NotEnoughMoney : UserCreateGameResult;
}