using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IBasketService
    {
        Task AddItemToBasketAsync(int basketId, int productId, int quantity);
        Task<int> BasketItemsCountAsync(int basketId);
        Task SetQuantities(int basketId, Dictionary<int, int> quantites);
        Task RemoveBasketItemAsync(int basketId, int basketItemId);
        Task DeleteBasketAsync(int basketId);
        Task TransferBasketAsync(string fromBuyerId, string toBuyerId);
    }
}
