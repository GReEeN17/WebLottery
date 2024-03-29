using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebLottery.Application.Contracts.ServiceAbstractions;
using WebLottery.Application.Models.Models;
using WebLottery.Presentation.Controllers.Astractions;

namespace WebLottery.Presentation.Controllers.EntityControllers;

public class CurrencyController(ICurrencyService currencyService) : BaseController
{
    [HttpGet("{id}")]
    public ActionResult<string> Get(Guid id)
    {
        var jsonCurrency = currencyService.GetCurrency(id);

        if (String.IsNullOrEmpty(jsonCurrency))
        {
            return BadRequest("Currency was not found");
        }
        
        return Ok(jsonCurrency);
    }
    
    [HttpGet]
    public ActionResult<string> GetAll()
    {
        var jsonCurrencies = currencyService.GetAllCurrencies();

        if (String.IsNullOrEmpty(jsonCurrencies))
        {
            return BadRequest("Currencies were not found");
        }
        
        return Ok(jsonCurrencies);
    }

    [HttpPost("create")]
    public async Task<ActionResult<string>> Create([FromBody] CurrencyModel currencyModel)
    {
        var jsonCurrency = await currencyService.CreateCurrency(currencyModel);
        
        if (String.IsNullOrEmpty(jsonCurrency))
        {
            return BadRequest("id is empty");
        }

        return Ok(jsonCurrency);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] CurrencyModel currencyModel)
    {
        await currencyService.UpdateCurrency(currencyModel);

        return Ok();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await currencyService.DeleteCurrency(id);

        return Ok();
    }
}