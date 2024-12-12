namespace DotlyApi.Models.DTO.IdentityDto;

public class AuthResponse
{
    public string UserName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Token { get; set; } = string.Empty;
    public string RefreshToken { get; set; } = string.Empty;
    public DateTime Expiration { get; set; } = DateTime.MinValue;
    public DateTime RefreshTokenExpiration { get; set; }
}