using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System.Linq;
using System.Threading.Tasks;
using Web.Interfaces;
using Web.ViewModels;

namespace Web.Services
{
    public class HomeViewModelService : IHomeViewModelService
    {
        private readonly IAsyncRepository<Product> productRepository;

        public HomeViewModelService(IAsyncRepository<Product> productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task<HomeViewModel> GetHomeViewModelAsync()
        {
            var products = await productRepository.ListAllAsync();
            var vm = new HomeViewModel()
            {
                Products = products.Select(p => new ProductViewModel()
                {
                    Id = p.Id,
                    ProductName = p.ProductName,
                    PicturePath = p.PicturePath,
                    Price = p.Price
                }).ToList()
            };
            return vm;
        }
    }
}
