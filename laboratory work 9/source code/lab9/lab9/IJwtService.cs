using System.Security.Claims;
using DotlyApi.Models.Domain.Identity;
using DotlyApi.Models.DTO.IdentityDto;

namespace DotlyApi.Services.Interfaces;

public interface IJwtService
{
    AuthResponse CreateJwtToken(AppUser user);
    ClaimsPrincipal? GetPrincipalFromJwtToken(string? token);
    
}


