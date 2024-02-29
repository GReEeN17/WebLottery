using AutoMapper;
using WebLottery.Application.Contracts.WalletCurrency;
using WebLottery.Application.Models.WalletCurrency;
using WebLottery.Infrastructure.Entities.WalletCurrency;
using WebLottery.Infrastructure.Implementations.Abstractions;

namespace WebLottery.Application.WalletCurrency;

public class WalletCurrencyService : IWalletCurrencyService
{
    private readonly IDbRepository _walletCurrencyRepository;
    private readonly IMapper _mapper;

    public WalletCurrencyService(
        IDbRepository walletCurrencyRepository,
        IMapper mapper)
    {
        _walletCurrencyRepository = walletCurrencyRepository;
        _mapper = mapper;
    }
    
    public void CreateWalletCurrency(int walletId, int currencyId)
    {
        WalletCurrencyModel walletCurrency = new WalletCurrencyModel
        {
            WalletId = walletId,
            CurrencyId = currencyId
        };

        WalletCurrencyEntity walletCurrencyEntity = _mapper.Map<WalletCurrencyEntity>(walletCurrency);
        
        int walletCurrencyId = _walletCurrencyRepository.Add(walletCurrencyEntity).Result;
    }

    public WalletCurrencyModel GetUserCurrency(int walletId, int currencyId)
    {
        return _walletCurrencyRepository.GetUserCurrency(walletId, currencyId).Result;
    }

    public IEnumerable<WalletCurrencyModel> GetAllUserCurrencies(int walletId)
    {
        return _walletCurrencyRepository.GetAllUserCurrency(walletId).ToBlockingEnumerable();
    }
}