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
    public class BL_Planilla
    {
        /// <summary>
        /// Método que permite generar la planilla
        /// </summary>

        public Planilla ProcesarPlanilla(DateTime Fecha)
        {
            DA_Planilla DAPlanilla = new DA_Planilla();
            DA_SueldoMinimo DASueldoMinimo = new DA_SueldoMinimo();
            DA_Uit DAUit = new DA_Uit();

            if(DAPlanilla.ExitePlanillaDeEsePeriodo(Fecha)) throw new Exception("PlanillaExiste");

            Planilla planilla = new Planilla();
            try
            {
                planilla.EmpleadoId_Aprueba = null;
                planilla.UitId = DAUit.UitActiva().UitId;
                planilla.Aprobado = false;
                planilla.Pagado = false;
                planilla.SueldoMinimoId = DASueldoMinimo.SueldoMinimoActivo().SueldoMinimoId;
                planilla.Fecha = Fecha;
                Calcular(planilla);
                return DAPlanilla.ProcesarPlanilla(planilla);
            }
            catch(Exception e)
            {
                EventLogger.EscribirLog(e.Message.ToString());
                throw new Exception(e.Message.ToString());
            }
        }

        public Planilla UltimaPlanilla(DateTime Fecha, Int32 PlanillaId)
        {
            DA_Planilla DAPlanilla = new DA_Planilla();
            try
            {
                return DAPlanilla.UltimaPlanilla(Fecha, PlanillaId);
            }
            catch(Exception e)
            {
                EventLogger.EscribirLog(e.Message.ToString());
                throw new Exception(e.Message.ToString());
            }
        }

        private static void Calcular(Planilla planilla)
        {
            DA_Concepto DaConceptos = new DA_Concepto();
            DA_Empleado DaEmpleados = new DA_Empleado();
            DA_Falta DAFalta = new DA_Falta();
            List<Concepto> Conceptos = DaConceptos.ListarConceptos();
            List<Empleado> Empleados = DaEmpleados.ListarEmpleadosActivosDetallado();

            foreach(var Empleado in Empleados)
            {
                //Empleado.Faltas = DAFalta.ListarFaltasPorMesAndEmpleado(planilla.Fecha, Empleado.EmpleadoId);
                decimal tot_I = 0.0m;
                decimal tot_D = 0.0m;
                decimal tot_A = 0.0m;

                var conceptosfiltados = (from x in Conceptos
                                         where x.TipoConcepto == 0 || x.TipoConcepto == ((bool)Empleado.EsAfp ? 1 : 2)
                                         select x).ToList();

                //var conceptosfiltados = Conceptos;
                PlanillaEmpleado planillaempleado = new PlanillaEmpleado();

                foreach(var concepto in conceptosfiltados)
                {
                    PlanillaEmpleadoConcepto planillaempleadoconcepto = new PlanillaEmpleadoConcepto();

                    decimal calculo = getImporte(Empleado, concepto.calculo1, planilla.Fecha);
                    if(!concepto.Operador1.Trim().Equals(""))
                    {
                        calculo = operar(Empleado, calculo, concepto.Operador1, concepto.calculo2);
                        if(!concepto.Operador2.Trim().Equals(""))
                        {
                            calculo = operar(Empleado, calculo, concepto.Operador2, concepto.calculo3);
                            if(!concepto.Operador3.Trim().Equals(""))
                            {
                                calculo = operar(Empleado, calculo, concepto.Operador3, concepto.calculo4);
                                if(!concepto.Operador4.Trim().Equals(""))
                                {
                                    calculo = operar(Empleado, calculo, concepto.Operador4, concepto.calculo5);
                                    if(!concepto.Operador5.Trim().Equals(""))
                                    {
                                        calculo = operar(Empleado, calculo, concepto.Operador5, concepto.calculo6);
                                    }
                                }
                            }
                        }
                    }
                    decimal valor = 0;

                    if(concepto.Escala1 <= calculo)
                    {
                        valor += concepto.Escala1 * concepto.Porcentaje1 / 100 + concepto.Importe1;
                        if(concepto.Escala2 <= calculo)
                        {
                            valor += (decimal)((concepto.Escala2 - concepto.Escala1) * concepto.Porcentaje2 / 100 + concepto.Importe2);
                            if(concepto.Escala3 <= calculo)
                            {
                                valor += (decimal)((concepto.Escala3 - concepto.Escala2) * concepto.Porcentaje3 / 100 + concepto.Importe3);
                                if(concepto.Escala4 <= calculo)
                                {
                                    valor += (decimal)((concepto.Escala4 - concepto.Escala3) * concepto.Porcentaje4 / 100 + concepto.Importe4);
                                    if(concepto.Escala5 <= calculo)
                                    {
                                        valor += (decimal)((concepto.Escala5 - concepto.Escala4) * concepto.Porcentaje5 / 100 + concepto.Importe5);
                                        if(concepto.Escala6 <= calculo)
                                        {
                                            valor += (decimal)((concepto.Escala6 - concepto.Escala5) * concepto.Porcentaje6 / 100 + concepto.Importe6);
                                        }
                                        else
                                        {
                                            valor += (decimal)((calculo - concepto.Escala5) * concepto.Porcentaje6 / 100 + concepto.Importe6);
                                        }
                                    }
                                    else
                                    {
                                        valor += (decimal)((calculo - concepto.Escala4) * concepto.Porcentaje5 / 100 + concepto.Importe5);
                                    }
                                }
                                else
                                {
                                    valor += (decimal)((calculo - concepto.Escala3) * concepto.Porcentaje4 / 100 + concepto.Importe4);
                                }
                            }
                            else
                            {
                                valor += (decimal)((calculo - concepto.Escala2) * concepto.Porcentaje3 / 100 + concepto.Importe3);
                            }
                        }
                        else
                        {
                            valor += (decimal)((calculo - concepto.Escala1) * concepto.Porcentaje2 / 100 + concepto.Importe2);
                        }
                    }
                    else
                    {
                        valor += calculo * concepto.Porcentaje1 / 100 + concepto.Importe1;
                    }

                    if(concepto.calculo1.Equals("12SUBA"))
                    {
                        valor /= 12;
                    }

                    switch(concepto.Tipo)
                    {
                        case 0:
                            tot_I += valor;
                            break;
                        case 1:
                            tot_D += valor;
                            break;
                        case 2:
                            tot_A += valor;
                            break;
                    }
                    planillaempleadoconcepto.Importe = valor;
                    planillaempleadoconcepto.ConceptoId = concepto.ConceptoId;

                    if(planillaempleado.PlanillaEmpleadoConceptoes == null) planillaempleado.PlanillaEmpleadoConceptoes = new List<PlanillaEmpleadoConcepto>();
                    planillaempleado.PlanillaEmpleadoConceptoes.Add(planillaempleadoconcepto);
                }
                planillaempleado.TotalAporte = tot_A;
                planillaempleado.TotalIngreso = tot_I;
                planillaempleado.TotalDescuento = tot_D;
                planillaempleado.TotalNeto = tot_I - tot_D;
                planillaempleado.EmpleadoId = Empleado.EmpleadoId;
                planillaempleado.AfpId = 1;
                planillaempleado.OnpId = 1;

                if(planilla.PlanillaEmpleadoes == null) planilla.PlanillaEmpleadoes = new List<PlanillaEmpleado>();
                planilla.PlanillaEmpleadoes.Add(planillaempleado);
            }
        }
        private static decimal getImporte(Empleado empleado, String campo, DateTime? Fecha = null)
        {
            decimal importe = 0;
            if(campo.Equals("TOTFAL"))
            {
                importe = getTotalFaltas(empleado);
            }
            else if(campo.Equals("SUEBAS"))
            {
                importe = getSueldoBase(empleado);
            }
            else if(campo.Equals("TOTTAR"))
            {
                importe = getTotalTardanzas(empleado, (DateTime)Fecha);
            }
            else if(campo.Equals("SUEMIN"))
            {
                importe = getSueldoMinimo();
            }
            else if(campo.Equals("APOAFP"))
            {
                importe = getAporteAfp(empleado);
            }
            else if(campo.Equals("SEGAFP"))
            {
                importe = getSeguroAfp(empleado);
            }
            else if(campo.Equals("COMAFP"))
            {
                importe = getComisionAfp(empleado);
            }
            else if(campo.Equals("APOONP"))
            {
                importe = getAporteOnp();
            }
            else if(campo.Equals("APOESA"))
            {
                importe = getAporteEssalud();
            }
            else if(campo.Equals("SEGVIL"))
            {
                importe = getSeguroVidaLey();
            }
            else if(campo.Equals("12SUBA"))
            {
                importe = getImpuestoRenta(empleado);
            }
            else if(campo.Equals("GRATIF"))
            {
                importe = getGratificacion(empleado);
            }
            else if(isNumeric(campo))
            {
                importe = Convert.ToDecimal(campo);
            }

            return importe;
        }

        public Planilla getPlanilla(DateTime Fecha)
        {
            DA_Planilla DAPlanilla = new DA_Planilla();
            try
            {
                return DAPlanilla.findPlanilla(Fecha);
            }
            catch(Exception e)
            {
                EventLogger.EscribirLog(e.Message.ToString());
                throw new Exception(e.Message.ToString());
            }
        }

        public Planilla getPlanillaCompleto(DateTime Fecha)
        {
            DA_Planilla DAPlanilla = new DA_Planilla();
            try
            {
                return DAPlanilla.findPlanilla(Fecha);
            }
            catch(Exception e)
            {
                EventLogger.EscribirLog(e.Message.ToString());
                throw new Exception(e.Message.ToString());
            }
        }

        public List<Planilla> getPlanillaAndDetalle(DateTime Fecha)
        {
            DA_Planilla DAPlanilla = new DA_Planilla();
            
            try
            {
                var planilla = DAPlanilla.findPlanillas(Fecha);
                //planilla.PlanillaEmpleadoes = DAPlanilla.findPlanillaDetalle(planilla);
                return planilla;
            }
            catch(Exception e)
            {
                EventLogger.EscribirLog(e.Message.ToString());
                throw new Exception(e.Message.ToString());
            }
        }

        public Planilla delPlanilla(Planilla planilla)
        {
            DA_Planilla DAPlanilla = new DA_Planilla();
            try
            {
                return DAPlanilla.delPlanilla(planilla);
            }
            catch(Exception e)
            {
                EventLogger.EscribirLog(e.Message.ToString());
                throw new Exception(e.Message.ToString());
            }
        }

        private static decimal getTotalFaltas(Empleado empleado)
        {
            if(empleado.Faltas == null || empleado.Faltas.Count <= 0) return 0.0m;

            return empleado.Faltas.Count();
        }

        private static decimal getSueldoBase(Empleado empleado)
        {
            if(empleado.EmpleadoSueldoBases == null || empleado.EmpleadoSueldoBases.Count <= 0) return 0.0m;
            var item = empleado.EmpleadoSueldoBases.Where(s => s.Estado).FirstOrDefault();
            if(item == null) return 0.0m;
            return item.SueldoBase;
        }

        private static decimal getTotalTardanzas(Empleado empleado, DateTime Fecha)
        {
            if(empleado.Tardanzas == null || empleado.Tardanzas.Count <= 0) return 0.0m;
            var items = empleado.Tardanzas.Where(s => s.FechaTardanza.Month.Equals(Fecha.Month) && s.FechaTardanza.Year.Equals(Fecha.Year));
            if(items == null) return 0.0m;
            return Convert.ToDecimal(items.Sum(s => s.Minutos));
        }

        public static Boolean isNumeric(String str)
        {
            if(str == null)
            {
                return false;
            }
            float output;
            return float.TryParse(str, out output);
        }

        private static decimal operar(Empleado empleado, decimal importe, String operador, String calculo)
        {
            switch(operador)
            {
                case "+":
                    importe += getImporte(empleado, calculo);
                    break;
                case "-":
                    importe -= getImporte(empleado, calculo);
                    break;
                case "*":
                    importe *= getImporte(empleado, calculo);
                    break;
                case "/":
                    importe /= getImporte(empleado, calculo);
                    break;
            }
            return importe;
        }

        private static decimal getSueldoMinimo()
        {
            DA_SueldoMinimo DASueldoMinimo = new DA_SueldoMinimo();
            var item = DASueldoMinimo.SueldoMinimoActivo();
            if(item == null) return 0.0m;
            return item.Valor;
        }

        private static decimal getAporteAfp(Empleado empleado)
        {
            if(empleado.EmpleadoAfps == null) return 0.0m;
            var items = empleado.EmpleadoAfps.Where(s => s.Estado).FirstOrDefault();
            if(items == null) return 0.0m;
            var afp = items.Afp;
            if(afp == null) return 0.0m;
            return afp.Aporte;
        }

        private static decimal getSeguroAfp(Empleado empleado)
        {
            if(empleado.EmpleadoAfps == null) return 0.0m;
            var items = empleado.EmpleadoAfps.Where(s => s.Estado).FirstOrDefault();
            if(items == null) return 0.0m;
            var afp = items.Afp;
            if(afp == null) return 0.0m;
            return afp.Seguro;
        }

        private static decimal getComisionAfp(Empleado empleado)
        {
            if(empleado.EmpleadoAfps == null) return 0.0m;
            var items = empleado.EmpleadoAfps.Where(s => s.Estado).FirstOrDefault();
            if(items == null) return 0.0m;
            var afp = items.Afp;
            if(afp == null) return 0.0m;
            return afp.Comision;
        }

        private static decimal getAporteOnp()
        {
            DA_Onp DAOnp = new DA_Onp();
            var item = DAOnp.OnpActivo();
            if(item == null) return 0.0m;
            return item.Aporte;
        }

        private static decimal getAporteEssalud()
        {
            DA_EsSalud DA_EsSalud = new DA_EsSalud();
            var essalud = DA_EsSalud.EsSaludActivo();
            if(essalud == null) return 0.0m;
            return essalud.Valor;

        }

        private static decimal getSeguroVidaLey()
        {
            DA_SeguroVidaLey DASeguroVidaLey = new DA_SeguroVidaLey();
            var segurovidaley = DASeguroVidaLey.SeguroVidaLeyActiva();
            if(segurovidaley == null) return 0.0m;
            return segurovidaley.Valor;
        }

        private static decimal getImpuestoRenta(Empleado empleado)
        {
            decimal remuneracion = 12 * getSueldoBase(empleado) + 2 * getGratificacion(empleado);
            remuneracion = remuneracion - 7 * getUIT();
            if(remuneracion < 0) remuneracion = 0;
            return remuneracion;
        }

        private static decimal getGratificacion(Empleado empleado)
        {
            return getSueldoBase(empleado);
        }

        private static int getUIT()
        {
            DA_Uit DAUit = new DA_Uit();
            var item = DAUit.UitActiva();
            if(item == null) return 0;
            return Convert.ToInt32(item.Valor);
        }
    }
}
