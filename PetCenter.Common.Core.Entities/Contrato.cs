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

    public partial class Contrato : IValidatableObject
    {
        public int ContratoId { get; set; }

        [Required]
        public int EmpleadoId { get; set; }

        public Nullable<bool> EsAfp { get; set; }

        [Required]
         public decimal SueldoBase { get; set; }

        public int UbigeoId { get; set; }

        [Required]
         public Nullable<decimal> JornadaTrabajo { get; set; }

        [Required]
        public string RenumeracionLetra { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> FechaInicio { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> FechaTermino { get; set; }

        public string Estado { get; set; }
        public string RutaArchivo { get; set; }
    
        public virtual Empleado Empleado { get; set; }
        public virtual Ubigeo Ubigeo { get; set; }

  
        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            List<ValidationResult> res = new List<ValidationResult>();
            if(FechaInicio < FechaTermino)
            {
                ValidationResult mss = new ValidationResult("Fecha Termino tiene que ser mayor a la fecha de Inicio");
                res.Add(mss);

            }
            return res;
        }
    }
}
