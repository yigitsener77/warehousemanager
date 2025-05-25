
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Core.Concretes.Entities
{
    public class Employee : IdentityUser
    {
        // Projeye uygun kimlik bilgileri ayrıca eklenir:
        [Required] //Veritabanına bu alanın 'NOT NULL' olacağı bilgisi gönderilir. Bu anotasyon (Annotation) sadece kendisin sonra gelen mülk (property/method/object) içindir.
        [StringLength(100)] //NVARCHAR(100)
        public string FirstName { get; set; }

        [Required, StringLength(100)] public string LastName { get; set; }

        [Required, ForeignKey("Warehouse")] public int WarehouseId { get; set; } //ForeignKey
        public virtual Warehouse Warehouse { get; set; }

        public virtual ICollection<Movement> Movements { get; set; }

        // Kullanıcı giriş yaptıktan sonra kimlik bilgilerini aktif tutmaya yarayan değerleri (cookie/çerez) oluşturur. Kullanıcı bazlıdır (client-side), saldırı sırasında kullanıcı etkilenir, sunucu etkilenmez.
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<Employee> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    // public class EmployeeRole : IdentityRole   {  } // Ekstra özel bir alan eklemeyeceksek kendi halini kullanabiliriz.
}
