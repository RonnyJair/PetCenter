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
    public class DA_Contrato
    {
        public List<Contrato> ListarContratos()
        {
            try
            {
                using (BdPetCenterEntities1 contexto = new BdPetCenterEntities1())
                {
                    List<Contrato> Contratos = (from x in contexto.Contratoes.Include("Empleado").Include("Ubigeo")
                                                select x).ToList();

                    return Contratos;
                }
            }
            catch (Exception e)
            {
                EventLogger.EscribirLog(e.Message.ToString());
                throw new Exception(e.Message.ToString());
            }
        }

        public List<Contrato> ListarContratosFiltro(string EmpleadoId)
        {
            try
            {
                using (BdPetCenterEntities1 contexto = new BdPetCenterEntities1())
                {
                    List<Contrato> Contratos = (from x in contexto.Contratoes
                                                where x.EmpleadoId.Equals(EmpleadoId)
                                                select x).ToList();

                    return Contratos;
                }
            }
            catch (Exception e)
            {
                EventLogger.EscribirLog(e.Message.ToString());
                throw new Exception(e.Message.ToString());
            }
        }

        public Contrato GetContrato(int ContratoId)
        {
            try
            {
                using(BdPetCenterEntities1 contexto = new BdPetCenterEntities1())
                {
                    List<Contrato> Contratos = (from x in contexto.Contratoes
                                                where x.ContratoId.Equals(ContratoId)
                                                select x).ToList();

                    return Contratos.First();
                }
            }
            catch(Exception e)
            {
                EventLogger.EscribirLog(e.Message.ToString());
                throw new Exception(e.Message.ToString());
            }
        }



        public Contrato GuardarContrato(Contrato Contrato)
        {
            try
            {
                using(BdPetCenterEntities1 contexto = new BdPetCenterEntities1())
                {
                    Contrato objeto = new Contrato();
                    if(Contrato.ContratoId <= 0) objeto = contexto.Contratoes.Add(Contrato);
                    else
                    {
                        contexto.Entry(Contrato).State = EntityState.Modified;
                        objeto = Contrato;
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

        public Contrato EliminarContrato(Contrato Contrato)
        {
            try
            {
                using(BdPetCenterEntities1 contexto = new BdPetCenterEntities1())
                {
                    Contrato objeto = new Contrato();

                    contexto.Entry(Contrato).State = EntityState.Deleted;
                    objeto = Contrato;

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
