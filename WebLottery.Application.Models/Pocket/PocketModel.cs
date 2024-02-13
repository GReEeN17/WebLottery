using WebLottery.Application.Models.User;

namespace WebLottery.Application.Models.Pocket;

public class PocketModel
{
    public int Id { get; set; }
    public UserModel UserEntity { get; set; }
    public List<PocketTicket.PocketTicketModel> PocketTickets { get; set; }
}