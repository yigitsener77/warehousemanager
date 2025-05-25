using Core.Abstracts.BaseModels;
using System.Collections.Generic;

namespace Core.Concretes.Entities
{
    public class Warehouse : BaseEntity
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public virtual ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();
        public virtual ICollection<Inventory> Inventories { get; set; }
    }
}
