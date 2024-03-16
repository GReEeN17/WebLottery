using AutoMapper;
using WebLottery.Application.Contracts.PocketTicket;
using WebLottery.Application.Models.PocketTicket;
using WebLottery.Infrastructure.Entities.PocketTicket;
using WebLottery.Infrastructure.Implementations.Abstractions;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace WebLottery.Application.PocketTicket;

public class PocketTicketService : IPocketTicketService
{
    private readonly IDbRepository _dbRepository;
    private readonly IMapper _mapper;

    public PocketTicketService(IDbRepository dbRepository, IMapper mapper)
    {
        _dbRepository = dbRepository;
        _mapper = mapper;
    }

    public async Task<string> CreatePocketTicket(PocketTicketModel pocketTicketModel)
    {
        var pocketTicketEntity = _mapper.Map<PocketTicketEntity>(pocketTicketModel);

        var result = await _dbRepository.Add(pocketTicketEntity);
        await _dbRepository.SaveChangesAsync();

        return JsonSerializer.Serialize(result);
    }

    public string GetPocketTicket(int pocketTicketId)
    {
        var pocketTicketEntity = _dbRepository.Get<PocketTicketEntity>().FirstOrDefault(x => x.Id == pocketTicketId);
        var pocketTicketModel = _mapper.Map<PocketTicketModel>(pocketTicketEntity);

        return JsonSerializer.Serialize(pocketTicketModel);
    }

    public async Task UpdatePocketTicket(PocketTicketModel pocketTicketModel)
    {
        var pocketTicketEntity = _mapper.Map<PocketTicketEntity>(pocketTicketModel);

        await _dbRepository.Update(pocketTicketEntity);
        await _dbRepository.SaveChangesAsync();
    }

    public async Task DeletePocketTicket(int pocketTicketId)
    {
        await _dbRepository.Delete<PocketTicketEntity>(pocketTicketId);
        await _dbRepository.SaveChangesAsync();
    }
}