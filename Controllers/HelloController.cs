using Microsoft.AspNetCore.Mvc;

namespace MinimalDaprService.Controllers;

[ApiController]
[Route("[controller]")]
public class HelloController : ControllerBase
{
    [HttpGet]
    public string Get() => "Hello from Dapr service!";
}