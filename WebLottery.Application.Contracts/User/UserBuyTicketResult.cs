namespace WebLottery.Application.Contracts.User;

public abstract record UserBuyTicketResult
{
    private UserBuyTicketResult() {}

    public sealed record Success : UserBuyTicketResult;

    public sealed record NotAuthorized : UserBuyTicketResult;

    public sealed record NotEnoughMoney : UserBuyTicketResult;
}