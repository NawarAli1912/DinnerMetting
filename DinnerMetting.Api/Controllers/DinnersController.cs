using Microsoft.AspNetCore.Mvc;

namespace DinnerMetting.Api.Controllers;


[Route("[controller]")]
public class DinnersController : ApiController
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(Array.Empty<string>());
    }
}
