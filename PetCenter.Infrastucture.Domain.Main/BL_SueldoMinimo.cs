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
    public class BL_SueldoMinimo
    {
        public SueldoMinimo SueldoMinimoActivo()
        {
            DA_SueldoMinimo DASueldoMinimo = new DA_SueldoMinimo();
            try
            {
                return DASueldoMinimo.SueldoMinimoActivo();
            }
            catch (Exception e)
            {
                EventLogger.EscribirLog(e.Message.ToString());
                throw new Exception(e.Message.ToString());
            }
        }
    }
}
