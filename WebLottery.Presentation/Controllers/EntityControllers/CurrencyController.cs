using Microsoft.AspNetCore.Mvc;
using WebLottery.Application.Contracts.Currency;
using WebLottery.Application.Models.Currency;
using WebLottery.Presentation.Controllers.Astractions;

namespace WebLottery.Presentation.Controllers.EntityControllers;

public class CurrencyController(ICurrencyService currencyService) : BaseController
{
    [HttpGet("{id}")]
    public ActionResult<string> Get(int id)
    {
        var jsonCurrency = currencyService.GetCurrency(id);

        if (String.IsNullOrEmpty(jsonCurrency))
        {
            return BadRequest("Currency was not found");
        }
        
        return Ok(jsonCurrency);
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
}