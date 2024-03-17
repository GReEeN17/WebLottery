using Microsoft.AspNetCore.Mvc;
using WebLottery.Application.Contracts.ServiceAbstractions;
using WebLottery.Application.Models.Models;
using WebLottery.Presentation.Controllers.Astractions;

namespace WebLottery.Presentation.Controllers.EntityControllers;

public class PocketTicketController(IPocketTicketService pocketTicketService) : BaseController
{
    [HttpGet("{id}")]
    public ActionResult<string> Get(Guid id)
    {
        var jsonPocketTicket = pocketTicketService.GetPocketTicket(id);

        if (String.IsNullOrEmpty(jsonPocketTicket))
        {
            return BadRequest("PocketTicket was not found");
        }
        
        return Ok(jsonPocketTicket);
    }

    [HttpPost("create")]
    public async Task<ActionResult<string>> Create([FromBody] PocketTicketModel pocketTicketModel)
    {
        var jsonPocketTicket = await pocketTicketService.CreatePocketTicket(pocketTicketModel);
        
        if (String.IsNullOrEmpty(jsonPocketTicket))
        {
            return BadRequest("id is empty");
        }

        return Ok(jsonPocketTicket);
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