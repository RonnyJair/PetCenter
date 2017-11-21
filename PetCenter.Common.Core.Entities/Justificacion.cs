//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PetCenter.Common.Core.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Justificacion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Justificacion()
        {
            this.Faltas = new HashSet<Falta>();
        }
    
        public int JustificacionId { get; set; }
        public Nullable<int> EmpleadoId { get; set; }
        public string Descripcion { get; set; }
        public string Documento { get; set; }
        public bool Estado { get; set; }
        public Nullable<int> UsuarioAprueba { get; set; }
        public Nullable<System.DateTime> FechaAprobacion { get; set; }
        public Nullable<int> UsuarioNiega { get; set; }
        public Nullable<System.DateTime> FechaNegacion { get; set; }
    
        public virtual Empleado Empleado { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Falta> Faltas { get; set; }
    }
}
