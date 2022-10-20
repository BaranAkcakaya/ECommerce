using ECommerce.Application.Repositories;
using ECommerce.Domain.Common;
using Microsoft.EntityFrameworkCore.Storage;

namespace ECommerce.Application.Interfaces.UnitOfWork
{
    public interface IUnitOfWork<T> where T : BaseEntity
    {
        public IBaseRepository<T> BaseRepository { get; set; }
        Task<bool> SaveChangesAsync();
    }
}
