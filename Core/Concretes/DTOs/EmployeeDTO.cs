using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Concretes.DTOs
{
    public class EmployeeDTO
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public WarehouseDTO Warehouse { get; set; }
    }

    public class InventoryDTO
    {
        public ProductDTO Product { get; set; }
        public WarehouseDTO Warehouse { get; set; }
        public int Quantity { get; set; }
    }

    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SKU { get; set; }
        public string Description { get; set; }
    }

    public class WarehouseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public bool Active { get; set; }
        public bool Deleted { get; set; }
        public IEnumerable<EmployeeDTO> Employees { get; set; } = new HashSet<EmployeeDTO>();
        public IEnumerable<InventoryDTO> Invertories { get; set; } = new HashSet<InventoryDTO>();
    }
}
