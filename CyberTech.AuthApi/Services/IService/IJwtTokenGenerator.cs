using CyberTech.AuthApi.Models;

namespace CyberTech.AuthApi.Services.IService
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(ApplicationUser applicationUser, IEnumerable<string> roles);
    }
}
