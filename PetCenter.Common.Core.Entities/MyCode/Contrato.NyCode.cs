using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetCenter.Common.Core.Entities
{
    public partial class Contrato
    {
        public int ContratoId { get; set; }

        [Required]
        public int EmpleadoId { get; set; }

        public Nullable<bool> EsAfp { get; set; }

        [Required(ErrorMessage = "Ingresar sueldo base")]
        public decimal SueldoBase { get; set; }

        public int UbigeoId { get; set; }

        [Required(ErrorMessage ="Ingresar jornada de trabajo")]
        [Range(4, 8, ErrorMessage = "El valor del campo Jornada de Trabajo debe estar entre 4 y 8")]
        public Nullable<decimal> JornadaTrabajo { get; set; }

        [Required(ErrorMessage = "Ingresar Remuneracion en letra")]
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
