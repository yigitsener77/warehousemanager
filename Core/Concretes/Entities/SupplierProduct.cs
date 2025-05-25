using Core.Abstracts.BaseModels;

namespace Core.Concretes.Entities
{
    public class SupplierProduct : BaseEntity
    {
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public int SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }
    }
}
