using BlazorAuth.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
namespace BlazorAuth.Services;

public class IdentityInformation
{   
    public bool IsAuthenticated { get; set; }
    public string Username { get; set; }
    public string UserId { get; set; }
}