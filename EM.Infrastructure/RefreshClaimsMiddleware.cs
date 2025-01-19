using System.Security.Claims;
using EM.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace EM.Infrastructure;

public class RefreshClaimsMiddleware
{
    private readonly RequestDelegate _next;

    public RefreshClaimsMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
    {
        if (context.User.Identity is { IsAuthenticated: true })
        {
            var user = await userManager.GetUserAsync(context.User);
            if (user != null)
            {
                var roles = await userManager.GetRolesAsync(user);
                var identity = (ClaimsIdentity)context.User.Identity;

                // Clear and update roles
                identity.RemoveClaim(identity.FindFirst(ClaimTypes.Role));
                foreach (var role in roles)
                {
                    identity.AddClaim(new Claim(ClaimTypes.Role, role));
                }
            }
        }

        await _next(context);
    }
}