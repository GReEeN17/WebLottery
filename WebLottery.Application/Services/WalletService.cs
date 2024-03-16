using System.Text.Json;
using AutoMapper;
using WebLottery.Application.Contracts.ServiceAbstractions;
using WebLottery.Application.Models.Models;
using WebLottery.Infrastructure.Entities.Entities;
using WebLottery.Infrastructure.Implementations.Abstractions;

namespace WebLottery.Application.Services;

public class WalletService(IDbRepository dbRepository, IMapper mapper) : IWalletService
{
    public async Task<string> CreateWallet(WalletModel walletModel)
    {
        var walletEntity = mapper.Map<WalletEntity>(walletModel);

        var walletEntityResult = await dbRepository.Add(walletEntity);
        await dbRepository.SaveChangesAsync();

        var result = new
        {
            Id = walletEntityResult.Id,
            UserId = walletEntityResult.UserId
        };

        return JsonSerializer.Serialize(result);
    }

    public string GetWallet(int walletId)
    {
        var walletEntity = dbRepository.Get<WalletEntity>().FirstOrDefault(x => x.Id == walletId);
        var walletModel = mapper.Map<WalletModel>(walletEntity);

        return JsonSerializer.Serialize(walletModel);
    }

    public async Task UpdateWallet(WalletModel walletModel)
    {
        var walletEntity = mapper.Map<WalletEntity>(walletModel);

        await dbRepository.Update(walletEntity);
        await dbRepository.SaveChangesAsync();
    }

    public async Task DeleteWallet(int walletId)
    {
        await dbRepository.Delete<WalletEntity>(walletId);
        await dbRepository.SaveChangesAsync();
    }
}