
using Microsoft.AspNetCore.Mvc;
using Entity.MultiDB.Entities.Models.Response;

namespace Entity.MultiDB.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HealthController : ControllerBase
{
    [HttpGet("check")]
    public IActionResult HealthCheck()
    {
        var response = new HealthCheckResponseModel();
        return Ok(response);
    }
}
