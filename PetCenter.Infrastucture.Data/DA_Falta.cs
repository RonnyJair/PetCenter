using PetCenter.Common.Core.Entities;
using PetCenter.Common.Core.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetCenter.Infrastucture.Data
{
    public class DA_Falta
    {
        public List<Falta> ListarFaltasPorMesAndEmpleado(DateTime Fecha, Int32 EmpleadoId)
        {
            // && x.FechaInicio.Month == Fecha.Month && x.Fecha.Year == Fecha.Year
            using(BdPetCenterEntities1 contexto = new BdPetCenterEntities1())
            {
                List<Falta> items = (from x in contexto.Faltas
                                     where x.EmpleadoId == EmpleadoId 
                                     select x).ToList();

                return items;
            }
        }
    }
}
