using System.Text.Json;
using AutoMapper;
using WebLottery.Application.Contracts.ServiceAbstractions;
using WebLottery.Application.Models.Models;
using WebLottery.Infrastructure.Entities.Entities;
using WebLottery.Infrastructure.Implementations.Abstractions;

namespace WebLottery.Application.Services;

public class WalletService : IWalletService
{
    private readonly IDbRepository _dbRepository;
    private readonly IMapper _mapper;

    public WalletService(IDbRepository dbRepository, IMapper mapper)
    {
        _dbRepository = dbRepository;
        _mapper = mapper;
    }
    
    public async Task<string> CreateWallet(WalletModel walletModel)
    {
        var walletEntity = _mapper.Map<WalletEntity>(walletModel);

        var walletEntityResult = await _dbRepository.Add(walletEntity);
        await _dbRepository.SaveChangesAsync();

        var result = new
        {
            Id = walletEntityResult.Id,
            UserId = walletEntityResult.UserId
        };

        return JsonSerializer.Serialize(result);
    }

    public string GetWallet(int walletId)
    {
        var walletEntity = _dbRepository.Get<WalletEntity>().FirstOrDefault(x => x.Id == walletId);
        var walletModel = _mapper.Map<WalletModel>(walletEntity);

        return JsonSerializer.Serialize(walletModel);
    }

    public async Task UpdateWallet(WalletModel walletModel)
    {
        var walletEntity = _mapper.Map<WalletEntity>(walletModel);

        await _dbRepository.Update(walletEntity);
        await _dbRepository.SaveChangesAsync();
    }

    public async Task DeleteWallet(int walletId)
    {
        await _dbRepository.Delete<WalletEntity>(walletId);
        await _dbRepository.SaveChangesAsync();
    }
}