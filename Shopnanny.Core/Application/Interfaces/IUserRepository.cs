using Shopnanny.Core.Entities;

namespace Shopnanny.Core.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<ApplicationUser> GetCurrentLoggedInUser();
    }
}
