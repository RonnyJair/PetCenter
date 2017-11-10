using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetCenter.Common.Core.Entities
{
    public partial class Empleado
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Empleado()
        {
            this.Asistencias = new HashSet<Asistencia>();
            this.EmpleadoAfps = new HashSet<EmpleadoAfp>();
            this.EmpleadoOnps = new HashSet<EmpleadoOnp>();
            this.EmpleadoSueldoBases = new HashSet<EmpleadoSueldoBase>();
            this.Faltas = new HashSet<Falta>();
            this.Planillas = new HashSet<Planilla>();
            this.PlanillaEmpleadoes = new HashSet<PlanillaEmpleado>();
            this.Tardanzas = new HashSet<Tardanza>();
            this.EstadoCivil = null;
        }

        public int EmpleadoId { get; set; }
        public int TipoDocumentoId { get; set; }
        public string CodigoEmpleado { get; set; }
        [Required(ErrorMessage = "Ingresar Apellido Paterno")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Ingrese Solo Letras")]
        public string ApellidoPaterno { get; set; }
        [Required(ErrorMessage = "Ingresar Apellido Materno")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Ingrese Solo Letras")]
        public string ApellidoMaterno { get; set; }
        [Required(ErrorMessage = "Ingresar Nombres")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Ingrese Solo Letras")]
        public string Nombres { get; set; }
        [Required(ErrorMessage = "Ingresar Fecha de Nacimiento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public System.DateTime FechaNacimiento { get; set; }

         [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public System.DateTime Fecha{ get; set; }

        public bool Sexo { get; set; }
        [Required(ErrorMessage = "Ingresar Direccion")]
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Movil { get; set; }
        [Required(ErrorMessage = "Ingresar Correo")]
        [RegularExpression("^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$", ErrorMessage = "Correo Invalido")]
        public string Correo { get; set; }
        public bool TieneHijo { get; set; }
        [Required(ErrorMessage = "Ingresar Documento")]
        public string Documento { get; set; }
        public bool Habilitado { get; set; }
        public bool EsAfp { get; set; }
        [Required(ErrorMessage = "Ingresar Lugar de Nacimiento")]
        public string LugarNacimiento { get; set; }
        [Required(ErrorMessage = "Ingrese Codigo de Salud")]
        public string CodigoEsSalud { get; set; }

        public Nullable<int> UbigeoId { get; set; }
        public string Referencia { get; set; }
        public Nullable<int> BancoId { get; set; }
        public Nullable<int> TipoCuentaId { get; set; }
        public string NumeroCuenta { get; set; }
        public Nullable<int> MonedaId { get; set; }
        public string TipoRegimen { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public Nullable<System.DateTime> FechaIngreso { get; set; }
        public string CUSSP { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public Nullable<System.DateTime> FechaInicioContrato { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public Nullable<System.DateTime> FechaFinContrato { get; set; }
        public Nullable<short> EstadoCivil { get; set; }

        public decimal xSueldoBase { get; set; }
        public decimal xIngresos { get; set; }
        public decimal xDescuento { get; set; }
        public decimal xNeto { get; set; }
        public decimal xAporte { get; set; }
        public decimal xSueldoDiario { get; set; }
        public decimal xSueldoHora { get; set; }
        public DateTime xFechaPago { get; set; }

        private String xNombreCompleto;

        public string XNombreCompleto
        {
            get
            {
                return xNombreCompleto = String.Format("{0} {1}, {2}", ApellidoPaterno, ApellidoMaterno, Nombres);
            }

            set
            {
                xNombreCompleto = value;
            }
        }

    }
}
