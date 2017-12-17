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
    public class BL_Contrato
    {
        public List<Contrato> ListarContratos()
        {
            DA_Contrato DAContrato = new DA_Contrato();
            try
            {
                return DAContrato.ListarContratos();
            }
            catch (Exception e)
            {
                EventLogger.EscribirLog(e.Message.ToString());
                throw new Exception(e.Message.ToString());
            }
        }

        public List<Contrato> ListarContratosFiltro(string NroContrato)
        {
            DA_Contrato DAContrato = new DA_Contrato();
            try
            {
                return DAContrato.ListarContratosFiltro(NroContrato);
            }
            catch (Exception e)
            {
                EventLogger.EscribirLog(e.Message.ToString());
                throw new Exception(e.Message.ToString());
            }
        }

        public Contrato GetContrato(int ContratoId)
        {
            DA_Contrato DAContrato = new DA_Contrato();
            try
            {
                return DAContrato.GetContrato(ContratoId);
            }
            catch(Exception e)
            {
                EventLogger.EscribirLog(e.Message.ToString());
                throw new Exception(e.Message.ToString());
            }
        }

        public Contrato GuardarContrato(Contrato Contrato)
        {
            DA_Contrato DAContrato = new DA_Contrato();
            try
            {
                //Aca deberia estar las validaciones logicas =v
                return DAContrato.GuardarContrato(Contrato);
            }
            catch(Exception e)
            {
                EventLogger.EscribirLog(e.Message.ToString());
                throw new Exception(e.Message.ToString());
            }
        }

        public Contrato EliminarContrato(Contrato ContratoId)
        {
            DA_Contrato DAContrato = new DA_Contrato();
            try
            {
                //Aca deberia estar las validaciones logicas =v
                return DAContrato.EliminarContrato(ContratoId);
            }
            catch(Exception e)
            {
                EventLogger.EscribirLog(e.Message.ToString());
                throw new Exception(e.Message.ToString());
            }
        }
    }
}
