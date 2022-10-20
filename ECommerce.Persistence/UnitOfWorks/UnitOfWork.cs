using ECommerce.Application.Interfaces.UnitOfWork;
using ECommerce.Application.Repositories;
using ECommerce.Domain.Common;
using ECommerce.Persistence.Contexts;

namespace ECommerce.Persistence.UnitOfWorks
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : BaseEntity
    {
        private readonly ECommerceDBContext _eCommerceDBContext;

        public IBaseRepository<T> BaseRepository { get; set; }

        public UnitOfWork(ECommerceDBContext eCommerceDBContext, IBaseRepository<T> baseRepository)
        {
            _eCommerceDBContext = eCommerceDBContext;
            BaseRepository = baseRepository;
        }

        public async Task<bool> SaveChangesAsync()
        {
            using (var dbContextTransaction = await _eCommerceDBContext.Database.BeginTransactionAsync())
            {
                try
                {
                    await _eCommerceDBContext.SaveChangesAsync();
                    dbContextTransaction.Commit();
                }
                catch (Exception)
                {
                    dbContextTransaction.Rollback();
                    return false;
                }
            }
            return true;
        }
    }
}
