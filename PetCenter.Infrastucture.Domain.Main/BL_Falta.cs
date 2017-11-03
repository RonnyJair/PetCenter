using PetCenter.Common.Core.Entities;
using PetCenter.Common.Utilities;
using PetCenter.Infrastucture.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetCenter.Infrastucture.Domain.Main
{
    public class BL_Falta
    {
        public List<Falta> ListarFaltasPorMesAndEmpleado(DateTime Fecha, Int32 EmpleadoId)
        {
            DA_Falta DAFalta = new DA_Falta();
            try
            {
                return DAFalta.ListarFaltasPorMesAndEmpleado(Fecha, EmpleadoId);
            }
            catch (Exception e)
            {
                EventLogger.EscribirLog(e.Message.ToString());
                throw new Exception(e.Message.ToString());
            }
        }
    }
}
