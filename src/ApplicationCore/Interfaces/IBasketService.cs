using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        Task TransferBasketAsync(int fromBuyerId, int toBuyerId);
    }
}
