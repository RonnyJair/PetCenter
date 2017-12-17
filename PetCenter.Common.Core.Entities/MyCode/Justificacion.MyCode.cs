using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetCenter.Common.Core.Entities
{
    public partial class Justificacion
    {
        [Required(ErrorMessage = "Ingresar empleado")]
        public Nullable<int> EmpleadoId { get; set; }
        [Required(ErrorMessage = "Ingresar descripción")]
        [StringLength(200, ErrorMessage ="El número de carácteres es demasiado largo")]
        public string Descripcion { get; set; }
        public string Documento { get; set; }
        [Required(ErrorMessage = "seleccionar estado")]
        public bool Estado { get; set; }

    }
}
