using Microsoft.AspNetCore.Authentication.Cookies;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace CyberTech.API.Middleware
{
    public class AuthenticatorMiddleware(RequestDelegate next, ILogger<AuthenticatorMiddleware> logger)
    {
        private readonly RequestDelegate _next = next;
        private readonly ILogger<AuthenticatorMiddleware> _logger = logger;

        public async Task InvokeAsync(HttpContext context)
        {
            string token = context.Request.Headers.Authorization;
            if (!string.IsNullOrEmpty(token) && token.StartsWith("Bearer "))
            {
                token = token["Bearer ".Length..].Trim();
                var handler = new JwtSecurityTokenHandler();
                if (!handler.CanReadToken(token)) return;

                var jwtToken = handler.ReadJwtToken(token);
                var name = jwtToken.Claims.Where(x => x.Type == "name").Select(x => x.Value).FirstOrDefault();
 
                var claims = new[] { new Claim(ClaimTypes.NameIdentifier, name) };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                context.User = new ClaimsPrincipal(identity);
                _logger.LogInformation(name, claims);
            }

            await _next(context);
        }
    }
}
