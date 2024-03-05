using Microsoft.AspNetCore.Mvc;
using WebLottery.Application.Contracts.Ticket;
using WebLottery.Application.Models.Ticket;
using WebLottery.Presentation.Controllers.Astractions;

namespace WebLottery.Presentation.Controllers.EntityControllers;

public class TicketController(ITicketService ticketService) : BaseController
{
    [HttpGet("{id}")]
    public ActionResult<string> Get(int id)
    {
        var jsonTicket = ticketService.GetTicket(id);

        if (String.IsNullOrEmpty(jsonTicket))
        {
            return BadRequest("Ticket was not found");
        }
        
        return Ok(jsonTicket);
    }
    
    [HttpGet("draw/{drawId}")]
    public ActionResult<string> GetDrawTickets(int drawId)
    {
        var jsonTickets = ticketService.GetDrawTickets(drawId);

        if (String.IsNullOrEmpty(jsonTickets))
        {
            return BadRequest("Tickets were not found");
        }
        
        return Ok(jsonTickets);
    }

    [HttpPost("create")]
    public async Task<ActionResult<string>> Create([FromBody] TicketModel ticketModel)
    {
        var jsonTicket = await ticketService.CreateTicket(ticketModel);
        
        if (String.IsNullOrEmpty(jsonTicket))
        {
            return BadRequest("id is empty");
        }

        return Ok(jsonTicket);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] TicketModel ticketModel)
    {
        await ticketService.UpdateTicket(ticketModel);

        return Ok();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await ticketService.DeleteTicket(id);

        return Ok();
    }
}