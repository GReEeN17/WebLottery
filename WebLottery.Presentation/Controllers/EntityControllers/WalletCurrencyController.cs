using Microsoft.AspNetCore.Mvc;
using WebLottery.Application.Contracts.ServiceAbstractions;
using WebLottery.Application.Models.Models;
using WebLottery.Presentation.Controllers.Astractions;

namespace WebLottery.Presentation.Controllers.EntityControllers;

public class WalletCurrencyController(IWalletCurrencyService walletCurrencyService) : BaseController
{
    [HttpGet("{id}")]
    public ActionResult<string> Get(Guid id)
    {
        var jsonWalletCurrency = walletCurrencyService.GetWalletCurrency(id);
        
        if (String.IsNullOrEmpty(jsonWalletCurrency))
        {
            return BadRequest("WalletCurrency was not found");
        }
        
        return Ok(jsonWalletCurrency);
    }
    
    [HttpPost]
    public async Task<ActionResult<string>> Create([FromBody] WalletCurrencyModel walletCurrencyModel)
    {
        var jsonWalletCurrency = await walletCurrencyService.CreateWalletCurrency(walletCurrencyModel);
        
        if (String.IsNullOrEmpty(jsonWalletCurrency))
        {
            return BadRequest("id is empty");
        }

        return Ok(jsonWalletCurrency);
    }
    
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] WalletCurrencyModel walletCurrencyModel)
    {
        await walletCurrencyService.UpdateWalletCurrency(walletCurrencyModel);

        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await walletCurrencyService.DeleteWalletCurrency(id);

        return Ok();
    }
}