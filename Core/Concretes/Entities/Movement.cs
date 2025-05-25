using Core.Abstracts.BaseModels;
using Core.Concretes.Constants;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Concretes.Entities
{
    public class Movement : BaseEntity
    {
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int Quantity { get; set; }
        /// <summary>
        /// just From Warehouse -> OUTBOUND <br/>
        /// just To Warehouse -> INBOUND <br/>
        /// From-To Warehouse -> TRANSFER 
        /// </summary>
        public MovementType Type { get; set; }


        [ForeignKey("From")] public int? FromId { get; set; }
        public Warehouse From { get; set; }

        [ForeignKey("To")] public int? ToId { get; set; }
        public Warehouse To { get; set; }

        // Identity kütüphanesi kullanıcı kimlik sütununu string olarak ayarlar.
        [ForeignKey("MovedBy")] public string MovedById { get; set; }
        public Employee MovedBy { get; set; }

        public DateTime MovedAt { get; set; } = DateTime.Now;
    }
}
