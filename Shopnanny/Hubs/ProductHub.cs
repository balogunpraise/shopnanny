using Microsoft.AspNetCore.SignalR;
using Shopnanny.Core.Entities;

namespace Shopnanny.Hubs
{
    public class ProductHub : Hub
    {
        public async Task AddToHotSale(Product product)
        {
            await Clients.All.SendAsync("UpdateHot", product);
        }
    }
}
