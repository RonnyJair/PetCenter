using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetCenter.Common.Core.Entities
{
    public partial class Concepto
    {
        //public TipoConceptoEnum TipoConceptox { get; set; }
    }
    public enum TipoConceptoEnum
    {
        General = 0,
        Afpr = 1,
        Onp = 2
    }
}
