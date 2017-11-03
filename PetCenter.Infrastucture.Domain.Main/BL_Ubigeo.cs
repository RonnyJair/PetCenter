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
    public class BL_Ubigeo
    {
        public List<Ubigeo> ListarUbigeo()
        {
            DA_Ubigeo DAUbigeo = new DA_Ubigeo();
            try
            {
                return DAUbigeo.ListarUbigeo();
            }
            catch (Exception e)
            {
                EventLogger.EscribirLog(e.Message.ToString());
                throw new Exception(e.Message.ToString());
            }
        }
    }
}
