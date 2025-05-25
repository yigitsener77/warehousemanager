using Core.Abstracts;
using Core.Abstracts.IRepositories;
using Data.Contexts;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class UnitOfWorks : IUnitOfWorks
    {
        private DataContext context = DataContext.Instance();

        private IProductRepository productRepository;
        public IProductRepository ProductRepository => productRepository = productRepository ?? new ProductRepository(context);

       
        private IWarehouseRepository warehouseRepository;
        public IWarehouseRepository WarehouseRepository => warehouseRepository = warehouseRepository ?? new WarehouseRepository(context);

      
        private ISupplierRepository supplierRepository;
        public ISupplierRepository SupplierRepository => supplierRepository = supplierRepository ?? new SupplierRepository(context);

       
        private ISupplierProductRepository supplierProductRepository;
        public ISupplierProductRepository SupplierProductRepository => supplierProductRepository = supplierProductRepository ?? new SupplierProductRepository(context);


        private IMovementRepository movementRepository;
        public IMovementRepository MovementRepository => movementRepository = movementRepository ?? new MovementRepository(context);

       
        private IInventoryRepository inventoryRepository;
        public IInventoryRepository InventoryRepository => inventoryRepository = inventoryRepository ?? new InventoryRepository(context);

        public async Task CommitAsync()
        {
            try
            {
                await context.SaveChangesAsync();
            }
            catch (Exception)
            {
                Dispose();
            }
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
