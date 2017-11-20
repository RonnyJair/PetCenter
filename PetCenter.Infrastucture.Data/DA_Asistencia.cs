using PetCenter.Common.Core.Entities;
using PetCenter.Common.Core.ORM;
using PetCenter.Common.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace PetCenter.Infrastucture.Data
{
    public class DA_Asistencia
    {
        public List<Asistencia> ListarAsistencias()
        {
            try
            {
                using(BdPetCenterEntities1 contexto = new BdPetCenterEntities1())
                {
                    List<Asistencia> Bancos = (from x in contexto.Asistencias.Include("Empleado")
                                               select x).ToList();

                    return Bancos;
                }
            }
            catch(Exception e)
            {
                EventLogger.EscribirLog(e.Message.ToString());
                throw new Exception(e.Message.ToString());
            }
        }

        public Asistencia GuardarAsistencia(Asistencia Asistencia)
        {
            try
            {
                using(BdPetCenterEntities1 contexto = new BdPetCenterEntities1())
                {
                    Asistencia objeto = new Asistencia();
                    if(Asistencia.EmpleadoId <= 0)
                    {
                        if(Asistencia.EmpleadoId == 0)
                        {
                            List<Empleado> empleados = (from x in contexto.Empleadoes
                                                       where  x.EmpleadoId.Equals(Asistencia.EmpleadoId)
                                                       select x).ToList();

                            Asistencia.EmpleadoId = empleados.First().EmpleadoId;
                        }
                        objeto = contexto.Asistencias.Add(Asistencia);
                    }
                    if(contexto.SaveChanges() > 0) return objeto;
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            return null;
        }
    }
}
