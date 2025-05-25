using Core.Abstracts.IRepositories;
using Core.Concretes.Entities;
using Data.Contexts;
using Utilities.Generics;

namespace Data.Repositories
{
    public class SupplierProductRepository : Repository<SupplierProduct>, ISupplierProductRepository
    {
        public SupplierProductRepository(DataContext db) : base(db)
        {
        }
    }
}
