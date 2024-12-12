using System.Security.Claims;
using DotlyApi.Models.Domain.Identity;
using DotlyApi.Models.DTO.IdentityDto;
using DotlyApi.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DotlyApi.Controllers;

[AllowAnonymous]
public class AuthController : ControllerBase
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly RoleManager<AppRole> _roleManager;
    private readonly IJwtService _jwtService;

    public AuthController(UserManager<AppUser> userManager,
        SignInManager<AppUser> signInManager,
        RoleManager<AppRole> roleManager,
        IJwtService jwtService)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _roleManager = roleManager;
        _jwtService = jwtService;
    }

    [HttpPost]
    [Authorize("NotAuthorized")]
    [Route("register")]
    public async Task<ActionResult<AppUser>> Register([FromBody] RegisterRequest registerRequest)
    {
        if (!ModelState.IsValid)
        {
            string errorMessage = string.Join("", ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage));
            return Problem(errorMessage, "Bad Request");
        }

        var user = new AppUser
        {
            UserName = registerRequest.UserName,
            Email = registerRequest.Email,
            FirstName = registerRequest.FirstName,
            LastName = registerRequest.LastName,
            Country = registerRequest.Country,
            City = registerRequest.City,
            BirthDate = registerRequest.BirthDate,
            PhoneNumber = registerRequest.PhoneNumber
        };

        var result = await _userManager.CreateAsync(user, registerRequest.Password);

        if (result.Succeeded)
        {
            if (registerRequest.UserType != UserTypeOptions.user)
            {
                return BadRequest("Invalid user type for registration.");
            }

            if (!await _roleManager.RoleExistsAsync(registerRequest.UserType.ToString()))
            {
                var role = new AppRole
                {
                    Name = registerRequest.UserType.ToString(),
                    NormalizedName = registerRequest.UserType.ToString().ToUpper()
                };

                await _roleManager.CreateAsync(role);
            }

            await _userManager.AddToRoleAsync(user, registerRequest.UserType.ToString());

            await _signInManager.SignInAsync(user, isPersistent: true);
            var authResponse = _jwtService.CreateJwtToken(user);
            user.RefreshToken = authResponse.RefreshToken;
            user.RefreshTokenExpiration = authResponse.RefreshTokenExpiration;
            await _userManager.UpdateAsync(user);

            return Ok(authResponse);
        }
        else
        {
            string errorMessage = string.Join("|", result.Errors.Select(e => e.Description));
            return Problem(errorMessage, "Bad Request");
        }
    }

    [HttpPost("login")]
    [Authorize("NotAuthorized")]
    public async Task<ActionResult<AppUser>> Login([FromBody] LoginRequest loginRequest)
    {
        if (!ModelState.IsValid)
        {
            string errorMessage = string.Join((""), ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage));
            return Problem(errorMessage, "Bad Request");
        }

        var result = await _signInManager.PasswordSignInAsync(loginRequest.UserName, loginRequest.Password,
            true, false);

        if (result.Succeeded)
        {
            AppUser? user = await _userManager.FindByNameAsync(loginRequest.UserName);
            if (user == null)
                return NoContent();

            var authResponse = _jwtService.CreateJwtToken(user);
            user.RefreshToken = authResponse.RefreshToken;
            user.RefreshTokenExpiration = authResponse.RefreshTokenExpiration;
            await _userManager.UpdateAsync(user);
            return Ok(authResponse);
        }
        else
        {
            return Problem("Login failed.");
        }
    }

    [HttpGet("logout")]
    public async Task<ActionResult<AppUser>> Logout()
    {
        await _signInManager.SignOutAsync();
        return Ok();
    }

    [HttpGet("is-email-registered")]
    public async Task<IActionResult> IsEmailAlreadyRegistered(string email)
    {
        AppUser user = await _userManager.FindByEmailAsync(email);
        if (user == null)
        {
            return Ok(true);
        }
        else
        {
            return Ok(false);
        }
    }

    [HttpPost("generate-new-token")]
    public async Task<ActionResult> GenerateNewToken(TokenModel tokenModel)
    {
        if (string.IsNullOrEmpty(tokenModel?.Token) || string.IsNullOrEmpty(tokenModel?.RefreshToken))
        {
            return BadRequest("Invalid token");
        }

        var principal = _jwtService.GetPrincipalFromJwtToken(tokenModel.Token);
        if (principal == null)
        {
            return BadRequest("Invalid token");
        }

        var email = principal.FindFirstValue(ClaimTypes.Email);
        var user = await _userManager.FindByEmailAsync(email);
        if (user == null || user.RefreshToken != tokenModel.RefreshToken
                         || user.RefreshTokenExpiration <= DateTime.UtcNow)
        {
            return Unauthorized("Invalid refresh token");
        }

        var authResponse = _jwtService.CreateJwtToken(user);
        user.RefreshToken = authResponse.RefreshToken;
        user.RefreshTokenExpiration = authResponse.RefreshTokenExpiration;

        await _userManager.UpdateAsync(user);
        return Ok(authResponse);
    }
}