using Shopnanny.Core.Entities;


namespace Shopnanny.Core.Application.Interfaces
{
    public interface ITokenSevice
    {
        string GenerateToken(ApplicationUser user);
    }
}
