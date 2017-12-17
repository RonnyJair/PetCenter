using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetCenter.Common.Core.Entities
{
    public partial class Contrato : IValidatableObject
    {

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            Contrato contrato = (Contrato)validationContext.ObjectInstance;
            if (contrato.EmpleadoId <= 0 ) yield return new ValidationResult("Seleccionar Empleado.");
            if (contrato.FechaInicio.Value.CompareTo((DateTime)contrato.FechaTermino.Value)==1) yield return new ValidationResult("La fecha de Inicio tiene que ser mayor a la de termino.");

            TimeSpan ts = (DateTime)contrato.FechaTermino - (DateTime)contrato.FechaInicio;
            int differenceInDays = ts.Days;
            if (ts.Days < 30) yield return new ValidationResult("Ingresar 30 dias de diferencia entre las fechas.");

            yield return ValidationResult.Success;
        }

        public int ContratoId { get; set; }

        [Required(ErrorMessage = "Ingrese el empleado")]
        public int EmpleadoId { get; set; }

        public Nullable<bool> EsAfp { get; set; }

        [Required(ErrorMessage = "Ingresar sueldo base")]
        [Range(1, 999999, ErrorMessage = "El valor del campo Sueldo maximo debe estar entre 1 y 999999 soles")]
        public decimal SueldoBase { get; set; }

        [Required(ErrorMessage = "Ingresar el ubigeo")]
        public int UbigeoId { get; set; }

        [Required(ErrorMessage = "Ingresar jornada de trabajo")]
        [Range(4, 8, ErrorMessage = "El valor del campo Jornada de Trabajo debe estar entre 4 y 8 horas")]
        public Nullable<decimal> JornadaTrabajo { get; set; }

        [Required(ErrorMessage = "Ingresar Remuneracion en letra")]
        [MaxLength(50, ErrorMessage = "No se admiten mas de 50 caracteres")]
        public string RenumeracionLetra { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Ingresar fecha inicio")]
        public Nullable<System.DateTime> FechaInicio { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Ingresar fecha termino")]
        public Nullable<System.DateTime> FechaTermino { get; set; }
    }
}
