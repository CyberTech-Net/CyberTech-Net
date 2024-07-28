using Microsoft.AspNetCore.Identity;

namespace CyberTech.AuthApi.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
