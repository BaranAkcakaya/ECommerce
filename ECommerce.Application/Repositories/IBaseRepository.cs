using ECommerce.Domain.Common;

namespace ECommerce.Application.Repositories
{
    public interface IBaseRepository<T> : IReadRepository<T>, IWriteRepository<T> where T : BaseEntity
    {
        
    }
}
