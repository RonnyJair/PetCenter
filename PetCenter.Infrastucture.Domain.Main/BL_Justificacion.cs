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
    public class BL_Justificacion
    {
        public List<Justificacion> ListarJustificacion()
        {
            DA_Justificacion DAJustificacion = new DA_Justificacion();
            try
            {
                return DAJustificacion.ListarJustificacion();
            }
            catch (Exception e)
            {
                EventLogger.EscribirLog(e.Message.ToString());
                throw new Exception(e.Message.ToString());
            }
        }

        public Justificacion GetJustificacion(int JustificacionId)
        {
            DA_Justificacion DAJustificacion = new DA_Justificacion();
            try
            {
                return DAJustificacion.GetJustificacion(JustificacionId);
            }
            catch (Exception e)
            {
                EventLogger.EscribirLog(e.Message.ToString());
                throw new Exception(e.Message.ToString());
            }
        }

        //public Concepto GuardarConcepto(Concepto Concepto)
        //{
        //    DA_Concepto DAConcepto = new DA_Concepto();
        //    try
        //    {
        //        //Aca deberia estar las validaciones logicas =v
        //        return DAConcepto.GuardarConcepto(Concepto);
        //    }
        //    catch (Exception e)
        //    {
        //        EventLogger.EscribirLog(e.Message.ToString());
        //        throw new Exception(e.Message.ToString());
        //    }
        //}

        //public Concepto EliminarConcepto(Concepto ConceptoId)
        //{
        //    DA_Concepto DAConcepto = new DA_Concepto();
        //    try
        //    {
        //        //Aca deberia estar las validaciones logicas =v
        //        return DAConcepto.EliminarConcepto(ConceptoId);
        //    }
        //    catch (Exception e)
        //    {
        //        EventLogger.EscribirLog(e.Message.ToString());
        //        throw new Exception(e.Message.ToString());
        //    }
        //}

        public List<Justificacion> ListarJustificacionFiltro(String Descripcion)
        {
            DA_Justificacion DAJustificacion = new DA_Justificacion();
            try
            {
                return DAJustificacion.ListarJustificacionFiltro(Descripcion);
            }
            catch (Exception e)
            {
                EventLogger.EscribirLog(e.Message.ToString());
                throw new Exception(e.Message.ToString());
            }
        }
    }
}
