using Core.Abstracts.BaseModels;

namespace Core.Concretes.Entities
{
    public class Inventory : BaseEntity
    {
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public int WarehouseId { get; set; }
        public virtual Warehouse Warehouse { get; set; }

        public int Quantity { get; set; }
    }
}
