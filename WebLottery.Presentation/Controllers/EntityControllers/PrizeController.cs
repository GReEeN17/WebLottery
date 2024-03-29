using Microsoft.AspNetCore.Mvc;
using WebLottery.Application.Contracts.ServiceAbstractions;
using WebLottery.Application.Models.Models;
using WebLottery.Presentation.Controllers.Astractions;

namespace WebLottery.Presentation.Controllers.EntityControllers;

public class PrizeController(IPrizeService prizeService) : BaseController
{
    [HttpGet("{id}")]
    public ActionResult<string> Get(Guid id)
    {
        var jsonPrize = prizeService.GetPrize(id);
        
        if (String.IsNullOrEmpty(jsonPrize))
        {
            return BadRequest("Prize was not found");
        }
        
        return Ok(jsonPrize);
    }
    
    [HttpPost]
    public async Task<ActionResult<string>> Create([FromBody] PrizeModel prizeModel)
    {
        var jsonPrize = await prizeService.CreatePrize(prizeModel);
        
        if (String.IsNullOrEmpty(jsonPrize))
        {
            return BadRequest("id is empty");
        }

        return Ok(jsonPrize);
    }
    
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] PrizeModel prizeModel)
    {
        await prizeService.UpdatePrize(prizeModel);

        return Ok();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await prizeService.DeletePrize(id);

        return Ok();
    }
}