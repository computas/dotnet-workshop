using Microsoft.AspNetCore.Mvc;

namespace BuberBreakfast.Controllers;

public class ErrorsController : ControllerBase
{
    [NonAction]
    [Route("/error")]
    public IActionResult Error()
    {
        return Problem();
    }
}