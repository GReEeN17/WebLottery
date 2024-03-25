using Microsoft.AspNetCore.Mvc;
using WebLottery.Application.Contracts.ServiceAbstractions;
using WebLottery.Application.Models.Models;
using WebLottery.Infrastructure.Entities.Entities;
using WebLottery.Presentation.Controllers.Astractions;

namespace WebLottery.Presentation.Controllers.EntityControllers;

public class TicketController(ITicketService ticketService) : BaseController
{
    [HttpGet("{id}")]
    public ActionResult<string> Get(Guid id)
    {
        var jsonTicket = ticketService.GetTicket(id);

        if (String.IsNullOrEmpty(jsonTicket))
        {
            return BadRequest("Ticket was not found");
        }
        
        return Ok(jsonTicket);
    }
    
    [HttpGet("draw/{drawId}")]
    public ActionResult<IEnumerable<TicketModel>> GetDrawTickets(Guid drawId)
    {
        var tickets = ticketService.GetDrawTickets(drawId);
        
        return Ok(tickets);
    }

    [HttpPost("create")]
    public async Task<ActionResult<TicketEntity>> Create([FromBody] TicketModel ticketModel)
    {
        var jsonTicket = await ticketService.CreateTicket(ticketModel);

        return Ok(jsonTicket);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] TicketModel ticketModel)
    {
        await ticketService.UpdateTicket(ticketModel);

        return Ok();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await ticketService.DeleteTicket(id);

        return Ok();
    }
}