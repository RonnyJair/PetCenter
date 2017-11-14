using PetCenter.Common.Core.Entities;
using PetCenter.Common.Utilities;
using PetCenter.Infrastucture.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetCenter.Common.Core.Entities.MyCode;

namespace PetCenter.Infrastucture.Domain.Main
{
    public class BL_Empleado
    {
        /// </summary>
        public List<Empleado> ListarEmpleadosActivos()
        {
            DA_Empleado DAEmpleado = new DA_Empleado();
            try
            {
                return DAEmpleado.ListarEmpleadosActivos();
            }
            catch(Exception e)
            {
                EventLogger.EscribirLog(e.Message.ToString());
                throw new Exception(e.Message.ToString());
            }
        }

        public List<Empleado> ListarEmpleados()
        {
            DA_Empleado DAEmpleado = new DA_Empleado();
            try
            {
                return DAEmpleado.ListarEmpleados();
            }
            catch(Exception e)
            {
                EventLogger.EscribirLog(e.Message.ToString());
                throw new Exception(e.Message.ToString());
            }
        }

        public List<Empleado> ListarEmpleadosActivosRecalculados(Planilla planilla)
        {
            DA_Empleado DAEmpleado = new DA_Empleado();
            try
            {
                var empleados = DAEmpleado.ListarEmpleadosActivosConsueldoBase();

                foreach(var item in planilla.PlanillaEmpleadoes)
                {
                    var empleado = empleados.Where(s => s.EmpleadoId == item.EmpleadoId).FirstOrDefault();
                    empleado.xAporte = item.TotalAporte;
                    empleado.xDescuento = item.TotalDescuento;
                    empleado.xIngresos = item.TotalIngreso;
                    decimal sueldobase = empleado.EmpleadoSueldoBases.Where(s => s.Estado).FirstOrDefault().SueldoBase;
                    empleado.xNeto = empleado.xIngresos - empleado.xDescuento;
                    empleado.xSueldoBase = sueldobase;
                    empleado.xSueldoDiario = empleado.xNeto / 30;
                    empleado.xSueldoHora = empleado.xSueldoDiario / 8;
                }

                return empleados;
            }
            catch(Exception e)
            {
                EventLogger.EscribirLog(e.Message.ToString());
                throw new Exception(e.Message.ToString());
            }
        }

        public List<Empleado> ListarEmpleadosActivoporPlanilla(List<Planilla> planilla)
        {
            DA_Empleado DAEmpleado = new DA_Empleado();
            try
            {
                var empleados = DAEmpleado.ListarEmpleadosActivosConsueldoBase();
                foreach(var itemplanilla in planilla)
                {
                    foreach(var item in itemplanilla.PlanillaEmpleadoes)
                    {
                        var empleado = empleados.Where(s => s.EmpleadoId == item.EmpleadoId).FirstOrDefault();
                        empleado.xAporte = item.TotalAporte;
                        empleado.xDescuento = item.TotalDescuento;
                        empleado.xIngresos = item.TotalIngreso;
                        decimal sueldobase = empleado.EmpleadoSueldoBases.Where(s => s.Estado).FirstOrDefault().SueldoBase;
                        empleado.xNeto = empleado.xIngresos - empleado.xDescuento;
                        empleado.xSueldoBase = sueldobase;
                        empleado.xSueldoDiario = empleado.xNeto / 30;
                        empleado.xSueldoHora = empleado.xSueldoDiario / 8;
                    }
                }

                return empleados;
            }
            catch(Exception e)
            {
                EventLogger.EscribirLog(e.Message.ToString());
                throw new Exception(e.Message.ToString());
            }
        }

        public List<Empleado> ListarEmpleadosActivoWhithPlanilla(Planilla planilla)
        {
            DA_Empleado DAEmpleado = new DA_Empleado();
            try
            {
                var empleados = DAEmpleado.ListarEmpleadosActivosConsueldoBase();

                foreach(var item in planilla.PlanillaEmpleadoes)
                {
                    var empleado = empleados.Where(s => s.EmpleadoId == item.EmpleadoId).FirstOrDefault();

                }

                return empleados;
            }
            catch(Exception e)
            {
                EventLogger.EscribirLog(e.Message.ToString());
                throw new Exception(e.Message.ToString());
            }
        }

        public Empleado GetEmpleadoId(Int32 EmpleadoId)
        {
            DA_Empleado DAEmpleado = new DA_Empleado();
            try
            {
                return DAEmpleado.GetEmpleadoId(EmpleadoId);
            }
            catch(Exception e)
            {
                EventLogger.EscribirLog(e.Message.ToString());
                throw new Exception(e.Message.ToString());
            }
        }

        public List<ConceptoDetalleBoleta> GetConceptoPorEmpleado(Int32 EmpleadoId)
        {
            DA_Empleado DAEmpleado = new DA_Empleado();
            try
            {
                return DAEmpleado.GetConceptoPorEmpleado(EmpleadoId);
            }
            catch(Exception e)
            {
                EventLogger.EscribirLog(e.Message.ToString());
                throw new Exception(e.Message.ToString());
            }
        }

        

        public Empleado GuardarEmpleado(Empleado empleado)
        {
            DA_Empleado DAEmpleado = new DA_Empleado();
            try
            {
                if(String.IsNullOrEmpty(empleado.EmpleadoId.ToString()))
                {
                    //GPE_RN0011_Codigo de empleado
                    Empleado UltimoEmpleado = DAEmpleado.GetUltimoEmpleado();
                    String cod = UltimoEmpleado.CodigoEmpleado.Trim().Substring(UltimoEmpleado.CodigoEmpleado.Length - 3, 3);
                    cod = "00" + (Convert.ToInt32(cod) + 1).ToString();
                    cod = cod.Substring(cod.Length - 3, 3).ToUpper();
                    empleado.CodigoEmpleado = String.Format("{0}{1}{2}{3}", empleado.ApellidoPaterno.Trim().Substring(0, 2), empleado.ApellidoMaterno.Trim().Substring(0, 2), empleado.Nombres.Trim().Substring(0, 1), cod);
                }
                return DAEmpleado.GuardarEmpleado(empleado);
            }
            catch(Exception e)
            {
                EventLogger.EscribirLog(e.Message.ToString());
                throw new Exception(e.Message.ToString());
            }
        }

        public Empleado EliminarEmpleado(Empleado Empleado)
        {
            DA_Empleado DAEmpleado = new DA_Empleado();
            try
            {
                Empleado.Habilitado = false;
                return DAEmpleado.GuardarEmpleado(Empleado);
            }
            catch(Exception e)
            {
                EventLogger.EscribirLog(e.Message.ToString());
                throw new Exception(e.Message.ToString());
            }
        }
    }
}
