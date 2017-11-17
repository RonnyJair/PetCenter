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
    public class DA_Justificacion
    {
        public List<Justificacion> ListarJustificacion()
        {
            try
            {
                using (BdPetCenterEntities1 contexto = new BdPetCenterEntities1())
                {
                    List<Justificacion> Justificacion = (from x in contexto.Justificacions
                                                select x).ToList();

                    return Justificacion;
                }
            }
            catch (Exception e)
            {
                EventLogger.EscribirLog(e.Message.ToString());
                throw new Exception(e.Message.ToString());
            }
        }

        public List<Justificacion> ListarJustificacionFiltro(String Descripcion)
        {
            try
            {
                using (BdPetCenterEntities1 contexto = new BdPetCenterEntities1())
                {
                    List<Justificacion> Justificacion = (from x in contexto.Justificacions
                                                where x.Descripcion.Contains(Descripcion)
                                                select x).ToList();

                    return Justificacion;
                }
            }
            catch (Exception e)
            {
                EventLogger.EscribirLog(e.Message.ToString());
                throw new Exception(e.Message.ToString());
            }
        }

        public Justificacion GetJustificacion(int JustificacionId)
        {
            try
            {
                using (BdPetCenterEntities1 contexto = new BdPetCenterEntities1())
                {
                    List<Justificacion> Justificacion = (from x in contexto.Justificacions
                                                where x.JustificacionId.Equals(JustificacionId)
                                                select x).ToList();

                    return Justificacion.First();
                }
            }
            catch (Exception e)
            {
                EventLogger.EscribirLog(e.Message.ToString());
                throw new Exception(e.Message.ToString());
            }
        }



        //public Concepto GuardarConcepto(Concepto concepto)
        //{
        //    try
        //    {
        //        using (BdPetCenterEntities1 contexto = new BdPetCenterEntities1())
        //        {
        //            Concepto objeto = new Concepto();
        //            if (concepto.ConceptoId <= 0) objeto = contexto.Conceptoes.Add(concepto);
        //            else
        //            {
        //                contexto.Entry(concepto).State = EntityState.Modified;
        //                objeto = concepto;
        //            }
        //            if (contexto.SaveChanges() > 0) return objeto;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message.ToString());
        //    }
        //    return null;
        //}

        //public Concepto EliminarConcepto(Concepto concepto)
        //{
        //    try
        //    {
        //        using (BdPetCenterEntities1 contexto = new BdPetCenterEntities1())
        //        {
        //            Concepto objeto = new Concepto();

        //            contexto.Entry(concepto).State = EntityState.Deleted;
        //            objeto = concepto;

        //            if (contexto.SaveChanges() > 0) return objeto;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message.ToString());
        //    }
        //    return null;
        //}
    }
}
