using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebLottery.Application.Contracts.ServiceAbstractions;
using WebLottery.Application.Models.Models;
using WebLottery.Presentation.Controllers.Astractions;

namespace WebLottery.Presentation.Controllers.EntityControllers;

public class DrawController(IDrawService drawService) : BaseController
{
    [HttpGet("{id}")]
    public ActionResult<string> Get(int id)
    {
        var jsonDraw = drawService.GetDraw(id);

        if (String.IsNullOrEmpty(jsonDraw))
        {
            return BadRequest("Draw was not found");
        }
        
        return Ok(jsonDraw);
    }
    
    [Authorize]
    [HttpGet]
    public ActionResult<string> GetAll()
    {
        var jsonDraws = drawService.GetALlDraws();

        if (String.IsNullOrEmpty(jsonDraws))
        {
            return BadRequest("Draws were not found");
        }
        
        return Ok(jsonDraws);
    }
    
    [HttpGet("some/{count}")]
    public ActionResult<string> GetSome(int count)
    {
        var jsonDraws = drawService.GetSomeDraws(count);

        if (String.IsNullOrEmpty(jsonDraws))
        {
            return BadRequest("Draws were not found");
        }
        
        return Ok(jsonDraws);
    }

    [HttpPost("create")]
    public async Task<ActionResult<string>> Create([FromBody] DrawModel drawModel)
    {
        var jsonDraw = await drawService.CreateDraw(drawModel);
        
        if (String.IsNullOrEmpty(jsonDraw))
        {
            return BadRequest("id is empty");
        }

        return Ok(jsonDraw);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] DrawModel drawModel)
    {
        await drawService.UpdateDraw(drawModel);

        return Ok();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await drawService.DeleteDraw(id);

        return Ok();
    }
}