using Microsoft.AspNetCore.Mvc;
using OneOf;
using PontoOpen.Application.ViewModels;

namespace PontoOpen.Api.Controllers;

[ApiController]
public abstract class ControllerApiBase<T> : ControllerBase
{
    protected IActionResult ResultResponse(OneOf<T, ErrorResponse> result, bool created = false, string urlCreated = "")
    {
        if (result.IsT0)
        {
            if(created && !string.IsNullOrWhiteSpace(urlCreated))
            {
                return Created(urlCreated, result.AsT0);
            }

            return Ok(result.AsT0);
        }

        return BadRequest(result.AsT1);
    }
}
