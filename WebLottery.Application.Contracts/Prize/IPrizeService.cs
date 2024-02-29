using WebLottery.Application.Models.Prize;

namespace WebLottery.Application.Contracts.Prize;

public interface IPrizeService
{
    Task<Guid> CreatePrize(string name, string? description, int? currencyId);
    Task<string> GetPrize(int prizeId);
    Task UpdatePrize(int prizeId, string? name, string? description, int? currencyId);
    Task DeletePrize(int prizeId);
}