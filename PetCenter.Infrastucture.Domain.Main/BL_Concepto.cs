using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetCenter.Common.Core.Entities;
using PetCenter.Common.Utilities;
using PetCenter.Infrastucture.Data;

namespace PetCenter.Infrastucture.Domain.Main
{
    public class BL_Concepto
    {
        public List<Concepto> ListarConceptos()
        {
            DA_Concepto DAConcepto = new DA_Concepto();
            try
            {
                return DAConcepto.ListarConceptos();
            }
            catch(Exception e)
            {
                EventLogger.EscribirLog(e.Message.ToString());
                throw new Exception(e.Message.ToString());
            }
        }

        public Concepto GetConcepto(int ConceptoId)
        {
            DA_Concepto DAConcepto = new DA_Concepto();
            try
            {
                return DAConcepto.GetConcepto( ConceptoId);
            }
            catch(Exception e)
            {
                EventLogger.EscribirLog(e.Message.ToString());
                throw new Exception(e.Message.ToString());
            }
        }

        public Concepto GuardarConcepto(Concepto Concepto)
        {
            DA_Concepto DAConcepto = new DA_Concepto();
            try
            {
                //Aca deberia estar las validaciones logicas =v
                return DAConcepto.GuardarConcepto(Concepto);
            }
            catch(Exception e)
            {
                EventLogger.EscribirLog(e.Message.ToString());
                throw new Exception(e.Message.ToString());
            }
        }

        public Concepto EliminarConcepto(Concepto ConceptoId)
        {
            DA_Concepto DAConcepto = new DA_Concepto();
            try
            {
                //Aca deberia estar las validaciones logicas =v
                return DAConcepto.EliminarConcepto(ConceptoId);
            }
            catch(Exception e)
            {
                EventLogger.EscribirLog(e.Message.ToString());
                throw new Exception(e.Message.ToString());
            }
        }

        public List<Concepto> ListarConceptosFiltro(String Nombre)
        {
            DA_Concepto DAConcepto = new DA_Concepto();
            try
            {
                return DAConcepto.ListarConceptosFiltro(Nombre);
            }
            catch(Exception e)
            {
                EventLogger.EscribirLog(e.Message.ToString());
                throw new Exception(e.Message.ToString());
            }
        }

    }
}
