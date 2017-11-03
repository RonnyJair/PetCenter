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
    public class BL_TipoCuenta
    {
        public List<TipoCuenta> ListarTipoCuenta()
        {
            DA_TipoCuenta DATipoCuenta = new DA_TipoCuenta();
            try
            {
                return DATipoCuenta.ListarTipoCuenta();
            }
            catch (Exception e)
            {
                EventLogger.EscribirLog(e.Message.ToString());
                throw new Exception(e.Message.ToString());
            }
        }
    }
}
