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
    public class DA_Banco
    {
        public List<Banco> ListarBancos()
        {
            try
            {
                using (BdPetCenterEntities1 contexto = new BdPetCenterEntities1())
                {
                    List<Banco> Bancos = (from x in contexto.Bancoes
                                                select x).ToList();

                    return Bancos;
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
