using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Shopnanny.Core.Application.Interfaces;
using Shopnanny.Core.Entities;
using System.Security.Claims;

namespace Shopnanny.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserRepository(IHttpContextAccessor httpContextAccessor, UserManager<ApplicationUser> userManager)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        public async Task<ApplicationUser> GetCurrentLoggedInUser()
        {
            var username = _httpContextAccessor.HttpContext.User?.FindFirst(ClaimTypes.NameIdentifier).Value;
            if(username != null)
            {
                return await _userManager.FindByNameAsync(username);
            }
            return null;
        }
    }
}
