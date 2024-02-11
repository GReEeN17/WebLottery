namespace WebLottery.Application.Contracts.Draws;

public record DrawEndDrawResult
{
    private DrawEndDrawResult() {}

    public sealed record Success : DrawEndDrawResult;
}