using Microsoft.AspNetCore.Mvc;

namespace lab7.Controllers;

[Route("api/v{version:ApiVersion}/[controller]")]
[ApiController]
public class CustomControllerBase: ControllerBase
{
    
}