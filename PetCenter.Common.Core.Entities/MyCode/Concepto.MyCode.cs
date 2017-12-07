using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetCenter.Common.Core.Entities
{
    public partial class Concepto : IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            Concepto concepto = (Concepto)validationContext.ObjectInstance;

            if(!String.IsNullOrEmpty(concepto.calculo2) || !String.IsNullOrEmpty(concepto.Operador2) || concepto.Escala2 != null || concepto.Porcentaje2 != null || concepto.Importe2 != null)
            {
                if(String.IsNullOrEmpty(concepto.calculo2)) yield return new ValidationResult("Ingresar Calculo 2.");
                if(String.IsNullOrEmpty(concepto.Operador2)) yield return new ValidationResult("Ingresar Operador 2.");
                if(concepto.Escala2 == null) yield return new ValidationResult("Ingresar Escala 2.");
                if(concepto.Porcentaje2 == null) yield return new ValidationResult("Ingresar Porcentaje 2.");
                if(concepto.Importe2 == null) yield return new ValidationResult("Ingresar Importe 2.");
            }

            if(!String.IsNullOrEmpty(concepto.calculo3) || !String.IsNullOrEmpty(concepto.Operador3) || concepto.Escala3 != null || concepto.Porcentaje3 != null || concepto.Importe3 != null)
            {
                if(String.IsNullOrEmpty(concepto.calculo3)) yield return new ValidationResult("Ingresar Calculo 3.");
                if(String.IsNullOrEmpty(concepto.Operador3)) yield return new ValidationResult("Ingresar Operador 3.");
                if(concepto.Escala3 == null) yield return new ValidationResult("Ingresar Escala 3.");
                if(concepto.Porcentaje3 == null) yield return new ValidationResult("Ingresar Porcentaje 3.");
                if(concepto.Importe3 == null) yield return new ValidationResult("Ingresar Importe 3.");
            }

            if(!String.IsNullOrEmpty(concepto.calculo4) || !String.IsNullOrEmpty(concepto.Operador4) || concepto.Escala4 != null || concepto.Porcentaje4 != null || concepto.Importe4 != null)
            {
                if(String.IsNullOrEmpty(concepto.calculo4)) yield return new ValidationResult("Ingresar Calculo 4.");
                if(String.IsNullOrEmpty(concepto.Operador4)) yield return new ValidationResult("Ingresar Operador 4.");
                if(concepto.Escala4 == null) yield return new ValidationResult("Ingresar Escala 4.");
                if(concepto.Porcentaje4 == null) yield return new ValidationResult("Ingresar Porcentaje 4.");
                if(concepto.Importe4 == null) yield return new ValidationResult("Ingresar Importe 4.");
            }

            if(!String.IsNullOrEmpty(concepto.calculo5) || !String.IsNullOrEmpty(concepto.Operador5) || concepto.Escala5 != null || concepto.Porcentaje5 != null || concepto.Importe5 != null)
            {
                if(String.IsNullOrEmpty(concepto.calculo5)) yield return new ValidationResult("Ingresar Calculo 5.");
                if(String.IsNullOrEmpty(concepto.Operador5)) yield return new ValidationResult("Ingresar Operador 5.");
                if(concepto.Escala5 == null) yield return new ValidationResult("Ingresar Escala 5.");
                if(concepto.Porcentaje5 == null) yield return new ValidationResult("Ingresar Porcentaje 5.");
                if(concepto.Importe5 == null) yield return new ValidationResult("Ingresar Importe 5.");
            }
            if(!String.IsNullOrEmpty(concepto.calculo6) || concepto.Escala6 != null || concepto.Porcentaje6 != null || concepto.Importe6 != null)
            {
                if(String.IsNullOrEmpty(concepto.calculo6)) yield return new ValidationResult("Ingresar Calculo 6.");
                // if(String.IsNullOrEmpty(concepto.Operador6)) yield return new ValidationResult("Ingresar Operador 6.");
                if(concepto.Escala6 == null) yield return new ValidationResult("Ingresar Escala 6.");
                if(concepto.Porcentaje6 == null) yield return new ValidationResult("Ingresar Porcentaje 6.");
                if(concepto.Importe6 == null) yield return new ValidationResult("Ingresar Importe 6.");
            }


            yield return ValidationResult.Success;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Concepto()
        {
            this.PlanillaEmpleadoConceptoes = new HashSet<PlanillaEmpleadoConcepto>();
        }

        public int ConceptoId { get; set; }
        [Required(ErrorMessage ="Ingresar Nombre")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Ingresar tipo")]
        [Range(0, 1, ErrorMessage = "El valor del campo Tipo debe estar entre 0 y 1")]
        public Nullable<short> Tipo { get; set; }

        [Required(ErrorMessage = "Ingresar Tipo Concepto")]
        [Range(0,1,ErrorMessage = "El valor del campo Tipo concepto debe estar entre 0 y 1")]
        public Nullable<short> TipoConcepto { get; set; }

        [Required(ErrorMessage = "Ingresar calculo1")]
        public string calculo1 { get; set; }
        public string calculo2 { get; set; }
        public string calculo3 { get; set; }
        public string calculo4 { get; set; }
        public string calculo5 { get; set; }
        public string calculo6 { get; set; }

        [Required(ErrorMessage = "Ingresar operacion1")]
        [RegularExpression(@"^[-+*/]*", ErrorMessage = "Solo caracteres * - / + ")]
        public string Operador1 { get; set; }
        [RegularExpression(@"^[-+*/]*", ErrorMessage = "Solo caracteres * - / + ")]
        public string Operador2 { get; set; }
        [RegularExpression(@"^[-+*/]*", ErrorMessage = "Solo caracteres * - / + ")]
        public string Operador3 { get; set; }
        [RegularExpression(@"^[-+*/]*", ErrorMessage = "Solo caracteres * - / + ")]
        public string Operador4 { get; set; }
        [RegularExpression(@"^[-+*/]*", ErrorMessage = "Solo caracteres * - / + ")]
        public string Operador5 { get; set; }

        [Required(ErrorMessage = "Ingresar escala1")]
        public decimal Escala1 { get; set; }
        public Nullable<decimal> Escala2 { get; set; }
        public Nullable<decimal> Escala3 { get; set; }
        public Nullable<decimal> Escala4 { get; set; }
        public Nullable<decimal> Escala5 { get; set; }
        public Nullable<decimal> Escala6 { get; set; }

        [Required(ErrorMessage = "Ingresar procentaje1")]
        public decimal Porcentaje1 { get; set; }
        public Nullable<decimal> Porcentaje2 { get; set; }
        public Nullable<decimal> Porcentaje3 { get; set; }
        public Nullable<decimal> Porcentaje4 { get; set; }
        public Nullable<decimal> Porcentaje5 { get; set; }
        public Nullable<decimal> Porcentaje6 { get; set; }
        [Required(ErrorMessage = "Ingresar importe1")]
        public decimal Importe1 { get; set; }
        public Nullable<decimal> Importe2 { get; set; }
        public Nullable<decimal> Importe3 { get; set; }
        public Nullable<decimal> Importe4 { get; set; }
        public Nullable<decimal> Importe5 { get; set; }
        public Nullable<decimal> Importe6 { get; set; }
    }
    public enum TipoConceptoEnum
    {
        General = 0,
        Afpr = 1,
        Onp = 2
    }
}
