using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebLottery.Application.Contracts.ServiceAbstractions;
using WebLottery.Application.Models.Models;
using WebLottery.Infrastructure.Entities.Entities;
using WebLottery.Presentation.Controllers.Astractions;

namespace WebLottery.Presentation.Controllers.EntityControllers;

public class DrawController(IDrawService drawService) : BaseController
{
    [HttpGet("{id}")]
    public ActionResult<DrawEntity> Get(Guid id)
    {
        var draw = drawService.GetDraw(id);
        
        return Ok(draw);
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
        var draw = await drawService.CreateDraw(drawModel);

        return Ok(draw);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] DrawModel drawModel)
    {
        await drawService.UpdateDraw(drawModel);

        return Ok();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await drawService.DeleteDraw(id);

        return Ok();
    }
}