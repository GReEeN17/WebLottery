using Microsoft.AspNetCore.Mvc;
using WebLottery.Application.Contracts.ServiceAbstractions;
using WebLottery.Application.Models.Models;
using WebLottery.Presentation.Controllers.Astractions;

namespace WebLottery.Presentation.Controllers.EntityControllers;

public class PocketTicketController(IPocketTicketService pocketTicketService) : BaseController
{
    [HttpGet("{id}")]
    public ActionResult<PocketTicketModel> Get(Guid id)
    {
        var pocketTicket = pocketTicketService.GetPocketTicket(id);
        
        return Ok(pocketTicket);
    }

    [HttpPost("create")]
    public async Task<ActionResult<PocketTicketModel>> Create([FromBody] PocketTicketModel pocketTicketModel)
    {
        var pocketTicket = await pocketTicketService.CreatePocketTicket(pocketTicketModel);

        return Ok(pocketTicket);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] PocketTicketModel pocketTicketModel)
    {
        await pocketTicketService.UpdatePocketTicket(pocketTicketModel);

        return Ok();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await pocketTicketService.DeletePocketTicket(id);

        return Ok();
    }
}