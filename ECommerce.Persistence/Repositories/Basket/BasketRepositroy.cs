using ECommerce.Application.Repositories;
using ECommerce.Domain.Entities;
using ECommerce.Persistence.Contexts;

namespace ECommerce.Persistence.Repositories
{
    public class BasketRepositroy : BaseRepository<Basket>, IBasketRepository
    {
        public BasketRepositroy(ECommerceDBContext eCommerceDBContext) : base(eCommerceDBContext)
        {
        }
    }
}
