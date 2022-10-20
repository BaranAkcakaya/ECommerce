using ECommerce.Domain.Common;

namespace ECommerce.Application.Repositories
{
    public interface IWriteRepository<T>: IRepository<T> where T : BaseEntity
    {
        Task<bool> AddAsync(T entity);
        Task<bool> AddRangeAsync(List<T> entity);
        bool Remove(T entity);
        Task<bool> Remove(int id);
        bool RemoveRange(List<T> entity);
        bool Update(T entity);
        Task<int> SaveChangeAsync();
    }
}
