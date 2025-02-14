using Microsoft.AspNetCore.Identity;

namespace LeaveManagementSystem.Web.Data;

public class ApplicationUser : IdentityUser
    {
    public string Name { get; set; }
    public string Family { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public string NationalId { get; set; }
    }