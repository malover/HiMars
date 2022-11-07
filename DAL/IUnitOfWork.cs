using DAL.Models;
using DAL.Repository;

namespace DAL
{
    public interface IUnitOfWork
    {
        GenericRepository<Category> CategoryRepository { get; }
        GenericRepository<Good> GoodRepository { get; }
        GenericRepository<Vendor> VendorRepository { get; }

        void Dispose();
        void Save();
    }
}
