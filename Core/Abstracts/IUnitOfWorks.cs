using Core.Abstracts.IRepositories;
using System;
using System.Threading.Tasks;

namespace Core.Abstracts
{
    public interface IUnitOfWorks : IDisposable
    {
        IProductRepository ProductRepository { get; }
        IWarehouseRepository WarehouseRepository { get; }
        ISupplierRepository SupplierRepository { get; }
        ISupplierProductRepository SupplierProductRepository { get; }
        IMovementRepository MovementRepository { get; }
        IInventoryRepository InventoryRepository { get; }
        Task CommitAsync();
    }
}
