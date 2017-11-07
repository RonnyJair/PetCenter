using PetCenter.Common.Core.Entities;
using PetCenter.Common.Core.ORM;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetCenter.Infrastucture.Data
{
    public class DA_Empleado
    {
        public List<Empleado> ListarEmpleadosActivos()
        {
            try
            {
                using(BdPetCenterEntities1 contexto = new BdPetCenterEntities1())
                {
                    contexto.Database.Connection.Open();
                    var Empleados = (from x in contexto.Empleadoes
                                     where (bool)x.Habilitado == true
                                     select x).ToList();

                    return Empleados;
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message.ToString());

            }                 
        }

        public List<Empleado> ListarEmpleadosActivosConsueldoBase()
        {
            try
            {
                using(BdPetCenterEntities1 contexto = new BdPetCenterEntities1())
                {
                    var Empleados = (from x in contexto.Empleadoes.Include("EmpleadoSueldoBases")
                                     where (bool)x.Habilitado == true
                                     select x).ToList();

                    return Empleados;
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message.ToString()); 
            }
        }

        public List<Empleado> ListarEmpleadosActivosDetallado()
        {
            try
            {
                using(BdPetCenterEntities1 contexto = new BdPetCenterEntities1())
                {
                    var Empleados = (from x in contexto.Empleadoes.Include("EmpleadoAfps").Include("EmpleadoOnps").Include("EmpleadoSueldoBases").Include("Tardanzas").Include("Faltas")
                                     where (bool)x.Habilitado == true
                                     select x).ToList();

                    foreach(var empleado in Empleados)
                    {
                        empleado.EmpleadoAfps = (from x in contexto.EmpleadoAfps.Include("Afp")
                                                 select x).ToList();


                    }

                    return Empleados;
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public List<Empleado> ListarEmpleados()
        {
            try
            {
                using(BdPetCenterEntities1 contexto = new BdPetCenterEntities1())
                {
                    var Empleados = (from x in contexto.Empleadoes.Include("Banco").Include("Moneda").Include("TipoCuenta").Include("TipoDocumento").Include("Ubigeo")
                                     select x).ToList();
                    return Empleados;
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public Empleado GetUltimoEmpleado()
        {
            try
            {
                using(BdPetCenterEntities1 contexto = new BdPetCenterEntities1())
                {
                    var Empleados = (from x in contexto.Empleadoes
                                     select x).OrderByDescending(s => s.EmpleadoId).ToList().FirstOrDefault();
                    return Empleados;
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public Empleado GetEmpleadoId(Int32 EmpleadoId)
        {
            try
            {
                using(BdPetCenterEntities1 contexto = new BdPetCenterEntities1())
                {
                    Empleado Empleado = (from x in contexto.Empleadoes.Include("Banco").Include("Moneda").Include("TipoCuenta").Include("TipoDocumento").Include("Ubigeo")
                                         where x.EmpleadoId == EmpleadoId
                                         select x).ToList().FirstOrDefault();
                    return Empleado;
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public Empleado GuardarEmpleado(Empleado empleado)
        {
            try
            {
                using(BdPetCenterEntities1 contexto = new BdPetCenterEntities1())
                {
                    Empleado objeto = new Empleado();
                    if(empleado.EmpleadoId <= 0) objeto = contexto.Empleadoes.Add(empleado);
                    else
                    {
                        contexto.Entry(empleado).State = EntityState.Modified;
                        objeto = empleado;
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
