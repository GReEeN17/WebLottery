using AutoMapper;
using WebLottery.Application.Models.Currency;
using WebLottery.Application.Models.Draw;
using WebLottery.Application.Models.Pocket;
using WebLottery.Application.Models.PocketTicket;
using WebLottery.Application.Models.Prize;
using WebLottery.Application.Models.Ticket;
using WebLottery.Application.Models.User;
using WebLottery.Application.Models.Wallet;
using WebLottery.Application.Models.WalletCurrency;
using WebLottery.Infrastructure.Entities.Currency;
using WebLottery.Infrastructure.Entities.Draw;
using WebLottery.Infrastructure.Entities.Pocket;
using WebLottery.Infrastructure.Entities.PocketTicket;
using WebLottery.Infrastructure.Entities.Prize;
using WebLottery.Infrastructure.Entities.Ticket;
using WebLottery.Infrastructure.Entities.User;
using WebLottery.Infrastructure.Entities.Wallet;
using WebLottery.Infrastructure.Entities.WalletCurrency;

namespace WebLottery.Presentation.ProjectMapper;

public class AppMappingProfile : Profile
{
    public AppMappingProfile()
    {
        CreateMap<CurrencyEntity, CurrencyModel>().ReverseMap();
        CreateMap<DrawEntity, DrawModel>().ReverseMap();
        CreateMap<PocketEntity, PocketModel>().ReverseMap();
        CreateMap<PocketTicketEntity, PocketTicketModel>().ReverseMap();
        CreateMap<PrizeEntity, PrizeModel>().ReverseMap();
        CreateMap<TicketEntity, TicketModel>().ReverseMap();
        CreateMap<UserEntity, UserModel>().ReverseMap();
        CreateMap<WalletEntity, WalletModel>().ReverseMap();
        CreateMap<WalletCurrencyEntity, WalletCurrencyModel>().ReverseMap();
    }
}