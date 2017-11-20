using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetCenter.Common.Core.Entities
{
   public partial class Ubigeo
    {
        private String xNombreCompleto;

        public string XNombreCompleto
        {
            get
            {
                return xNombreCompleto = String.Format("{0} {1}, {2}", Distrito, Provincia, Departamento);
            }

            set
            {
                xNombreCompleto = value;
            }
        }
    }
}
