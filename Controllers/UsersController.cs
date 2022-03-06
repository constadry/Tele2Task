using Microsoft.AspNetCore.Mvc;
using Tele2Task.Services;
using Tele2Task.Extensions;

namespace Tele2Task.Controllers;

[ApiController]
[Produces("application/json")]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;
    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
            
        var result = await _userService.GetAll();

        return Ok(result);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetUser(string id)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
            
        var result = await _userService.Get(id);

        return Ok(result);
    }
}