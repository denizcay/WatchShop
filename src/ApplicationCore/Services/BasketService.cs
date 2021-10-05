using ApplicationCore.Entities;
using ApplicationCore.Exceptions;
using ApplicationCore.Interfaces;
using ApplicationCore.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class BasketService : IBasketService
    {
        private readonly IAsyncRepository<Basket> _basketRepository;
        private readonly IAsyncRepository<BasketItem> _basketItemRepository;

        public BasketService(IAsyncRepository<Basket> basketRepository, IAsyncRepository<BasketItem> basketItemRepository)
        {
            _basketRepository = basketRepository;
            _basketItemRepository = basketItemRepository;
        }
        public async Task AddItemToBasketAsync(int basketId, int productId, int quantity)
        {
            if (quantity < 1)
                throw new ArgumentOutOfRangeException("Quantity must be a positive number");
    
            var basket = await GetBasketWithItemsAsync(basketId);

            BasketItem item = basket.Items.FirstOrDefault(x => x.ProductId == productId);

            if (item != null)
                item.Quantity += quantity;
            else
            {
                item = new BasketItem()
                {
                    BasketId = basketId,
                    ProductId = productId,
                    Quantity = quantity
                };
                basket.Items.Add(item);
            }

            await _basketRepository.UpdateAsync(basket);
        }

        public Task<int> BasketItemsCountAsync(int basketId)
        {
            var spec = new BasketItemsSpecification(basketId);
            return _basketItemRepository.CountAsync(spec);
        }

        public async Task DeleteBasketAsync(int basketId)
        {
            var basket = await GetBasketWithItemsAsync(basketId);

            await _basketRepository.DeleteAsync(basket);
        }

        public async Task SetQuantities(int basketId, Dictionary<int, int> quantites)
        {
            // Get basket and update items 
            var basket = await GetBasketWithItemsAsync(basketId);

            foreach (var item in basket.Items)
            {
                int newValue;
             
                if (quantites.TryGetValue(item.Id, out newValue))
                {
                    if (newValue < 1)
                        throw new ArgumentOutOfRangeException("Quantity must be a positive number");
                    item.Quantity = newValue;
                }
            }

            await _basketRepository.UpdateAsync(basket);
        }
        public async Task RemoveBasketItemAsync(int basketId, int basketItemId)
        {
            var basket = await GetBasketWithItemsAsync(basketId);
            basket.Items.RemoveAll(x => x.Id == basketItemId);
            await _basketRepository.UpdateAsync(basket);
        }

        private async Task<Basket> GetBasketWithItemsAsync(int basketId)
        {
            var spec = new BasketWithItemsSpecification(basketId);
            Basket basket = await _basketRepository.FirstOrDefaultAsync(spec);

            if (basket == null)
                throw new BasketNotFoundException(basketId);

            return basket;
        }

        public async Task TransferBasketAsync(int fromBuyerId, int toBuyerId)
        {
            // TODO: get from buyer basket 
        }
    }
}
