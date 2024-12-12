using System.ComponentModel.DataAnnotations;
using DotlyApi.Models.Domain.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DotlyApi.Models.DTO.IdentityDto;

public class RegisterRequest
{
    [Required(ErrorMessage = "FirstName is required")]
    public string FirstName { get; set; }
    [Required(ErrorMessage = "LastName is required")]
    public string LastName { get; set; }
    [Required(ErrorMessage = "UserName is required")]
    public string UserName { get; set; }
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid Email Address")]
    [Remote(action: "IsEmailAlreadyRegistered", controller: "Account", ErrorMessage = "Email already registered")]
    public string Email { get; set; }
    [Required(ErrorMessage = "Phone number is required")]
    [DataType(DataType.PhoneNumber)]
    public string PhoneNumber { get; set; }
    [Required(ErrorMessage = "Password is required")]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    [Required(ErrorMessage = "Confirm Password")]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "Passwords don't match")]
    public string ConfirmPassword { get; set; }
    [Required(ErrorMessage = "BirthDate is required")]
    [DataType(DataType.Date)]
    public DateTime BirthDate { get; set; }
    [Required(ErrorMessage = "Country is required")]
    public string Country { get; set; }
    [Required(ErrorMessage = "City is required")]
    public string City { get; set; }
    public UserTypeOptions UserType { get; set; } = UserTypeOptions.user;
}