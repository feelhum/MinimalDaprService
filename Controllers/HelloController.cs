using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace MinimalDaprService.Controllers;

[ApiController]
[Route("[controller]")]
public class HelloController : ControllerBase
{
    private readonly IConfiguration _configuration;

    public HelloController(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    [HttpGet]
    public string Get() => "Hello from Dapr service!";

    [HttpGet]
    public IActionResult GetConsul()
    {
        var val = _configuration["myapp/config/mykey"];
        return Ok($"Config Value: {val}");
    }
}

