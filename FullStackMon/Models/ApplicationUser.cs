using Microsoft.AspNetCore.Identity;

namespace FullStackMon.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string? Address { get; set; }
    }
}
