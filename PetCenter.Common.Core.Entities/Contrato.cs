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
    using System.ComponentModel.DataAnnotations;

    public partial class Contrato
    {
        [Required(ErrorMessage="Ingrese el estado")]
        [Range(0, 1, ErrorMessage = "El valor del campo Tipo concepto debe estar entre 0 y 1")]
        public string Estado { get; set; }
        public string RutaArchivo { get; set; }
    
        public virtual Empleado Empleado { get; set; }
        public virtual Ubigeo Ubigeo { get; set; }
    }
}
