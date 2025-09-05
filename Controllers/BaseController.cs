using Microsoft.AspNetCore.Mvc;

namespace ubuntu_health_api.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  [Produces("application/json")]
  [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
  public abstract class BaseController : ControllerBase
  {
    protected IActionResult HandleResult<T>(T? result) where T : class
    {
      if (result == null)
        return NotFound();

      return Ok(result);
    }

    protected IActionResult HandleResult<T>(IEnumerable<T>? result) where T : class
    {
      if (result == null || !result.Any())
        return NotFound();

      return Ok(result);
    }

    protected IActionResult HandleCreatedResult<T>(T result, string actionName, object routeValues) where T : class
    {
      return CreatedAtAction(actionName, routeValues, result);
    }
  }
}
