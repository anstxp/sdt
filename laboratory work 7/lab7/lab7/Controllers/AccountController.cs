using lab7.Models.Domain.Files;
using lab7.Models.DTO.FilesDTO;
using lab7.Repositories.Implementation.FilesRepositories;
using lab7.Repositories.Interfaces;
using lab7.Services.Interfaces;
using lab7.Models.Domain.IdentityEntities;
using lab7.Models.DTO;
using lab7.Models.DTO.AppUserDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace lab7.Controllers
{
    [Route("[controller]/[action]")]
    [AllowAnonymous]
    [ApiVersion("1.0")]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<AppRole> _roleManager;

        public AccountController(UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        [HttpPost]
        [Authorize("NotAuthorized")]
        [Route("Register")]
        public async Task<ActionResult<AppUser>> Register([FromBody] RegisterDTO registerDTO)
        {
            if (!ModelState.IsValid)
            {
                string errorMessage = string.Join((""), ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage));
                return Problem(errorMessage, "Bad Request");
            }

            var user = new AppUser
            {
                UserName = registerDTO.UserName,
                Email = registerDTO.Email,
                FirstName = registerDTO.FirstName,
                LastName = registerDTO.LastName,
                Country = registerDTO.Country,
                City = registerDTO.City,
                BirthDate = registerDTO.BirthDate,
                PhoneNumber = registerDTO.PhoneNumber,
                ProfilePictureUrl = "/default-images/default-profile.jpg",
            };

            var result = await _userManager.CreateAsync(user, registerDTO.Password);

            if (result.Succeeded)
            {
                if (registerDTO.UserType != UserTypeOptions.User)
                {
                    throw new InvalidOperationException("Invalid user type for registration.");
                }
                await _userManager.AddToRoleAsync(user, registerDTO.UserType.ToString());
                await _signInManager.SignInAsync(user, isPersistent: true);
                return Ok(user);            
            }
            else 
            { 
                string errorMessage = string.Join(("|"), result.Errors.Select(e => e.Description));
                return Problem(errorMessage, "Bad Request");
            }
        }

        [HttpPost("Login")]
        [Authorize("NotAuthorized")]
        public async Task<ActionResult<AppUser>> Login([FromBody] LoginDTO loginDTO, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                string errorMessage = string.Join((""), ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage));
                return Problem(errorMessage, "Bad Request");
            }
            
            var result = await _signInManager.PasswordSignInAsync(loginDTO.Email, loginDTO.Password, 
                true, false);
            if (result.Succeeded)
            {
                AppUser? user = await _userManager.FindByEmailAsync(loginDTO.Email);
                if(user == null)
                    return NoContent();
                
                return Ok(new { name = user.UserName, email = user.Email });
            }
            else
            {
                return Problem("Login failed.");
            }
        }

        [HttpGet("Logout")]
        public async Task<ActionResult<AppUser>> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok();
        }

        [HttpGet("IsEmailAlreadyRegistered")]
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
        
    }
}