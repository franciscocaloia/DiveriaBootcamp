using Microsoft.AspNetCore.Mvc;

namespace webapi2.Controllers;

[ApiController]
[Route("[controller]")]
public class AhorcadoController : ControllerBase
{

    private readonly ILogger<AhorcadoController> _logger;
    public AhorcadoController(ILogger<AhorcadoController> logger)
    {
        _logger = logger;
    }

}
