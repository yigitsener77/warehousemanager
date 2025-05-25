using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Abstracts.BaseModels
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public bool Active { get; set; } = true;
        public bool Deleted { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
    }
}
