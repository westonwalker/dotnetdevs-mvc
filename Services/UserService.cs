using dotnetdevs.Models;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace dotnetdevs.Services
{

    public class UserService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserService(UserManager<ApplicationUser> userManager)
        {
            this._userManager = userManager;
        }

        public async Task<ApplicationUser?> GetAuthenticatedUser(ClaimsPrincipal user)
        {
            if (user.Identity != null && user.Identity.IsAuthenticated)
			{
				return await _userManager.GetUserAsync(user);
			}
            return null;
        }
    }
}
