using WebLottery.Application.Models.Models;

namespace WebLottery.Application.Contracts.DbResponses;

public class EndDrawDbResponse
{
    public Guid DrawId { get; set; }
    public PrizeModel Prize { get; set; }
    public Guid WinnerId { get; set; }
}