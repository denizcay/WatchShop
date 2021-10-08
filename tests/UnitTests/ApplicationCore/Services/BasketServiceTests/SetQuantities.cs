using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Services;
using ApplicationCore.Specifications;
using Ardalis.Specification;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.ApplicationCore.Services.BasketServiceTests
{
    public class SetQuantities
    {
        private readonly Mock<IAsyncRepository<Basket>> _mockBasketRepository;
        private readonly Mock<IAsyncRepository<BasketItem>> _mockBasketItemRepository;
        private readonly int _existingBasketId = 777;
        private readonly string _existingBuyerId = "7815b4b3-fd5e-47e9-9925-9c6a74c72fb6";
        public SetQuantities()
        {
            _mockBasketRepository = new Mock<IAsyncRepository<Basket>>();

            _mockBasketItemRepository = new Mock<IAsyncRepository<BasketItem>>();

        }

        [Fact]
        public async Task ThrowsArgumentOutOfRangeExceptionWhenNonNegativeQuantityGiven()
        {
            Basket basket = new Basket()
            {
                Id = _existingBasketId,
                BuyerId = _existingBuyerId,
                Items = new List<BasketItem>()
                {
                    new BasketItem() {Id = 101, Quantity = 8},
                    new BasketItem() {Id = 102, Quantity = 5}
                }

            };

            _mockBasketRepository.Setup(x => x.FirstOrDefaultAsync(It.IsAny<BasketWithItemsSpecification>()))
                .ReturnsAsync(basket);

            var basketService = new BasketService(_mockBasketRepository.Object, _mockBasketItemRepository.Object);
            Dictionary<int, int> quantities = new Dictionary<int, int>()
            {
                { 101, 3 },
                { 102, -1 }
            };
            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () =>
            {
                await basketService.SetQuantities(_existingBasketId, quantities);
            });
        }
    }
}
