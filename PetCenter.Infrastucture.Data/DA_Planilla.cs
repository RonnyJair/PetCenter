using PetCenter.Common.Core.Entities;
using PetCenter.Common.Core.ORM;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PetCenter.Infrastucture.Data
{
    public class DA_Planilla
    {
        public Planilla UltimaPlanilla(DateTime Fecha, Int32 PlanillaId)
        {
            try
            {
                using (BdPetCenterEntities1 contexto = new BdPetCenterEntities1())
                {
                    Planilla objeto = (from x in contexto.Planillas.Include("PlanillaEmpleadoes")
                                       where x.PlanillaId == PlanillaId
                                       select x).ToList().FirstOrDefault();
                    foreach (var item in objeto.PlanillaEmpleadoes)
                    {
                        item.PlanillaEmpleadoConceptoes = (from x in contexto.PlanillaEmpleadoConceptoes
                                                           where x.PlanillaEmpleadoId == item.PlanillaEmpleadoId
                                                           select x).ToList();
                    }

                    return objeto;
                }
            }
            catch (System.Exception ex)
            {

            }
            return null;

        }


        public bool ExitePlanillaDeEsePeriodo(DateTime Fecha)
        {
            try
            {
                using (BdPetCenterEntities1 contexto = new BdPetCenterEntities1())
                {
                    List<Planilla> objeto = (from x in contexto.Planillas
                                             where x.Fecha.Value.Year == Fecha.Year && x.Fecha.Value.Month == Fecha.Month
                                             select x).ToList();

                    return objeto.Count > 0;
                }
            }
            catch (System.Exception ex)
            {

            }
            return false;

        }

        public Planilla ProcesarPlanilla(Planilla Planilla)
        {
            try
            {
                using (BdPetCenterEntities1 contexto = new BdPetCenterEntities1())
                {
                    Planilla objeto = contexto.Planillas.Add(Planilla);

                    if (contexto.SaveChanges() > 0) return objeto;

                }
            }
            catch (System.Exception ex)
            {

            }
            return null;

        }

        public Planilla findPlanilla(DateTime Fecha)
        {
            try
            {
                using (BdPetCenterEntities1 contexto = new BdPetCenterEntities1())
                {
                    List<Planilla> objeto = (from x in contexto.Planillas
                                             where x.Fecha.Value.Year == Fecha.Year && x.Fecha.Value.Month == Fecha.Month && x.Fecha.Value.Day == Fecha.Day
                                             select x).ToList();
                    if (objeto.Count > 0)
                    {
                        return objeto[0];
                    }
                }
            }
            catch (System.Exception ex)
            {

            }
            return null;

        }

        public Planilla delPlanilla(Planilla Planilla)
        {
            try
            {
                using (BdPetCenterEntities1 contexto = new BdPetCenterEntities1())
                {
                    List<Planilla> objeto = contexto.Planillas.Where(s => s.PlanillaId == Planilla.PlanillaId).ToList();
                    foreach (var item in objeto)
                    {
                        item.PlanillaEmpleadoes = contexto.PlanillaEmpleadoes.Where(s => s.PlanillaId == Planilla.PlanillaId).ToList();
                        foreach (var empleados in item.PlanillaEmpleadoes)
                        {
                            empleados.PlanillaEmpleadoConceptoes = contexto.PlanillaEmpleadoConceptoes.Where(s => s.PlanillaEmpleadoId == empleados.PlanillaEmpleadoId).ToList();
                            contexto.PlanillaEmpleadoConceptoes.RemoveRange(empleados.PlanillaEmpleadoConceptoes);
                        }
                    }


                    foreach (var item in objeto)
                    {
                        contexto.PlanillaEmpleadoes.RemoveRange(item.PlanillaEmpleadoes);
                    }

                    contexto.Planillas.RemoveRange(objeto);

                    if (contexto.SaveChanges() > 0) return objeto.First();
                }
            }
            catch (System.Exception ex)
            {

            }
            return null;

        }
    }
}
