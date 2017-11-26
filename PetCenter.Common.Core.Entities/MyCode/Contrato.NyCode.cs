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

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> FechaInicio { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> FechaTermino { get; set; }
    }
}
