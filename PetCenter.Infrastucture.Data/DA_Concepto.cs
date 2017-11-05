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
    public class DA_Concepto
    {
        public List<Concepto> ListarConceptos()
        {
            try
            {
                using(BdPetCenterEntities1 contexto = new BdPetCenterEntities1())
                {
                    List<Concepto> Conceptos = (from x in contexto.Conceptoes
                                                select x).ToList();

                    return Conceptos;
                }
            }
            catch(Exception e)
            {
                EventLogger.EscribirLog(e.Message.ToString());
                throw new Exception(e.Message.ToString());
            }
        }

        public Concepto GetConcepto(int ConceptoId)
        {
            try
            {
                using(BdPetCenterEntities1 contexto = new BdPetCenterEntities1())
                {
                    List<Concepto> Conceptos = (from x in contexto.Conceptoes
                                                where x.ConceptoId.Equals(ConceptoId)
                                                select x).ToList();

                    return Conceptos.First();
                }
            }
            catch(Exception e)
            {
                EventLogger.EscribirLog(e.Message.ToString());
                throw new Exception(e.Message.ToString());
            }
        }



        public Concepto GuardarConcepto(Concepto concepto)
        {
            try
            {
                using(BdPetCenterEntities1 contexto = new BdPetCenterEntities1())
                {
                    Concepto objeto = new Concepto();
                    if(concepto.ConceptoId <= 0) objeto = contexto.Conceptoes.Add(concepto);
                    else
                    {
                        contexto.Entry(concepto).State = EntityState.Modified;
                        objeto = concepto;
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

        public Concepto EliminarConcepto(Concepto concepto)
        {
            try
            {
                using(BdPetCenterEntities1 contexto = new BdPetCenterEntities1())
                {
                    Concepto objeto = new Concepto();

                    contexto.Entry(concepto).State = EntityState.Deleted;
                    objeto = concepto;

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
