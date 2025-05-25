using Core.Abstracts.BaseModels;
using System.Collections.Generic;

namespace Core.Concretes.Entities
{
    public class Supplier : BaseEntity
    {
        public string CompanyName { get; set; }
        public string CompanyPerson { get; set; }
        public string Location { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public virtual ICollection<SupplierProduct> SupplierProducts { get; set; }
    }
}
