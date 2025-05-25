using Core.Abstracts.BaseModels;
using System.Collections.Generic;

namespace Core.Concretes.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string SKU { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Inventory> Inventories { get; set; }
        public virtual ICollection<Movement> Movements { get; set; }
        public virtual ICollection<SupplierProduct> SupplierProducts { get; set; }
    }
}
