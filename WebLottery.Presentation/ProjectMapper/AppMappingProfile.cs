using AutoMapper;
using WebLottery.Application.Models.Models;
using WebLottery.Infrastructure.Entities.Entities;
using WebLottery.Infrastructure.Entities.User;

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