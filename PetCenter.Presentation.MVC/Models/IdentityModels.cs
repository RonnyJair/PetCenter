using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace PetCenter.Presentation.MVC.Models
{
    // Puede agregar datos del perfil del usuario agregando más propiedades a la clase ApplicationUser. Para más información, visite http://go.microsoft.com/fwlink/?LinkID=317594.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Tenga en cuenta que el valor de authenticationType debe coincidir con el definido en CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Agregar aquí notificaciones personalizadas de usuario
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<PetCenter.Common.Core.Entities.Planilla> Planillas { get; set; }

        public System.Data.Entity.DbSet<PetCenter.Common.Core.Entities.SueldoMinimo> SueldoMinimoes { get; set; }

        public System.Data.Entity.DbSet<PetCenter.Common.Core.Entities.Uit> Uits { get; set; }

        public System.Data.Entity.DbSet<PetCenter.Common.Core.Entities.Empleado> Empleadoes { get; set; }

        public System.Data.Entity.DbSet<PetCenter.Common.Core.Entities.TipoDocumento> TipoDocumentoes { get; set; }

        public System.Data.Entity.DbSet<PetCenter.Common.Core.Entities.Banco> Bancoes { get; set; }

        public System.Data.Entity.DbSet<PetCenter.Common.Core.Entities.Moneda> Monedas { get; set; }

        public System.Data.Entity.DbSet<PetCenter.Common.Core.Entities.TipoCuenta> TipoCuentas { get; set; }

        public System.Data.Entity.DbSet<PetCenter.Common.Core.Entities.Ubigeo> Ubigeos { get; set; }

        public System.Data.Entity.DbSet<PetCenter.Common.Core.Entities.Concepto> Conceptoes { get; set; }
    }
}