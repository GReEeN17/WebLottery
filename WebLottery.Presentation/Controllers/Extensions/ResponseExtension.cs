using System.Net;
using Microsoft.AspNetCore.Mvc;
using WebLottery.Application.Contracts.ResponsesAbstractions;

namespace WebLottery.Presentation.Controllers.Extensions;

public static class ResponseExtension<T>
{
    public static ActionResult<T> GetResponseResult(IResponse<T> response)
    {
        return response.Status switch
        {
            HttpStatusCode.OK => new OkObjectResult(response.Value),
            HttpStatusCode.BadRequest => new BadRequestObjectResult(response.Value),
            HttpStatusCode.Forbidden => new ForbidResult(),
            HttpStatusCode.InternalServerError => new StatusCodeResult((int) HttpStatusCode.InternalServerError),
            _ => throw new ArgumentOutOfRangeException(nameof(response.Status), response.Status, null)
        };
    }
}