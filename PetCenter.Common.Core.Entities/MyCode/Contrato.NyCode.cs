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
    }
}
