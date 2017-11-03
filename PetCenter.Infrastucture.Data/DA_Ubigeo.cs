using PetCenter.Common.Core.Entities;
using PetCenter.Common.Core.ORM;
using PetCenter.Common.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetCenter.Infrastucture.Data
{
    public class DA_Ubigeo
    {
        public List<Ubigeo> ListarUbigeo()
        {
            try
            {
                using (BdPetCenterEntities1 contexto = new BdPetCenterEntities1())
                {
                    List<Ubigeo> Ubigeos = (from x in contexto.Ubigeos
                                            select x).ToList();

                    return Ubigeos;
                }
            }
            catch (Exception e)
            {
                EventLogger.EscribirLog(e.Message.ToString());
                throw new Exception(e.Message.ToString());
            }
        }
    }
}
