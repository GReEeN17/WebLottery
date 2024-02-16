using WebLottery.Application.Models.PocketTicket;
using WebLottery.Application.Models.User;

namespace WebLottery.Application.Models.Pocket;

public class PocketModel
{
    public int Id { get; set; }
    public UserModel User { get; set; }
    public List<PocketTicketModel> PocketTickets { get; set; }
}