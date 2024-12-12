using System.ComponentModel.DataAnnotations;

namespace DotlyApi.Models.DTO.IdentityDto;

public class LoginRequest
{
    [Required(ErrorMessage = "UserName is required")]
    public string? UserName { get; set; }
    
    [Required(ErrorMessage = "Password is required")]
    [DataType(DataType.Password)]
    public string? Password { get; set; }
}