using AutoMapper;
using ShoppingCart.Contracts.IRepositories;
using ShoppingCart.Contracts.IServices;

namespace ShoppingCart.Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<ICartService> cartService;
        private readonly Lazy<ICartItemService> cartItemService;

        public ServiceManager(IRepositoryManager repositoryManager, IMapper mapper)
        {
            cartService = new Lazy<ICartService>(() => new CartService(repositoryManager, mapper));
            cartItemService = new Lazy<ICartItemService>(() => new CartItemService(repositoryManager, mapper));
        }

        public ICartService CartService => cartService.Value;

        public ICartItemService CartItemService => cartItemService.Value;
    }
}
