using Microsoft.AspNetCore.Mvc;
using WebLottery.Application.Contracts.ServiceAbstractions;
using WebLottery.Application.Models.Models;
using WebLottery.Presentation.Controllers.Astractions;

namespace WebLottery.Presentation.Controllers.EntityControllers;

public class PocketController(IPocketService pocketService) : BaseController
{
    [HttpGet("{id}")]
    public ActionResult<string> Get(Guid id)
    {
        var jsonPocket = pocketService.GetPocket(id);

        if (String.IsNullOrEmpty(jsonPocket))
        {
            return BadRequest("Pocket was not found");
        }
        
        return Ok(jsonPocket);
    }

    [HttpPost("create")]
    public async Task<ActionResult<string>> Create([FromBody] PocketModel pocketModel)
    {
        var jsonPocket = await pocketService.CreatePocket(pocketModel);
        
        if (String.IsNullOrEmpty(jsonPocket))
        {
            return BadRequest("id is empty");
        }

        return Ok(jsonPocket);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] PocketModel pocketModel)
    {
        await pocketService.UpdatePocket(pocketModel);

        return Ok();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await pocketService.DeletePocket(id);

        return Ok();
    }
}