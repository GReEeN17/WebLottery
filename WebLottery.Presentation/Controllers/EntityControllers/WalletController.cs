using Microsoft.AspNetCore.Mvc;
using WebLottery.Application.Contracts.ServiceAbstractions;
using WebLottery.Application.Models.Models;
using WebLottery.Presentation.Controllers.Astractions;

namespace WebLottery.Presentation.Controllers.EntityControllers;

public class WalletController(IWalletService walletService) : BaseController
{
    [HttpGet("{id}")]
    public ActionResult<string> Get(Guid id)
    {
        var jsonWallet = walletService.GetWallet(id);
        
        if (String.IsNullOrEmpty(jsonWallet))
        {
            return BadRequest("Wallet was not found");
        }
        
        return Ok(jsonWallet);
    }
    
    [HttpPost]
    public async Task<ActionResult<string>> Create([FromBody] WalletModel walletModel)
    {
        var jsonWallet = await walletService.CreateWallet(walletModel);
        
        if (String.IsNullOrEmpty(jsonWallet))
        {
            return BadRequest("id is empty");
        }

        return Ok(jsonWallet);
    }
    
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] WalletModel walletModel)
    {
        await walletService.UpdateWallet(walletModel);

        return Ok();
    }
    
    [HttpDelete]
    public async Task<IActionResult> Delete(Guid id)
    {
        await walletService.DeleteWallet(id);

        return Ok();
    }
}