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
    
    public partial class EmpleadoAfp
    {
        public int EmpleadoAfpId { get; set; }
        public int EmpleadoId { get; set; }
        public int AfpId { get; set; }
        public bool Estado { get; set; }
    
        public virtual Afp Afp { get; set; }
        public virtual Empleado Empleado { get; set; }
    }
}
