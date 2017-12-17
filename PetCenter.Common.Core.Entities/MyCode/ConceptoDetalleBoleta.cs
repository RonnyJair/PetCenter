using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetCenter.Common.Core.Entities.MyCode
{
    public class ConceptoDetalleBoleta
    {
        private String m_TipoImporte;
        public String Concepto { get; set; }
        public String Importe { get; set; }

        public string TipoImporte
        {
            get
            {
                return m_TipoImporte;
            }

            set
            {
                var x = value;
                if (x == "0") m_TipoImporte = "Ingreso";
                else if (x == "1") m_TipoImporte = "Descuento";
                else if (x == "2") m_TipoImporte = "Aporte";
                else m_TipoImporte = "";
            }
        }
    }
}
