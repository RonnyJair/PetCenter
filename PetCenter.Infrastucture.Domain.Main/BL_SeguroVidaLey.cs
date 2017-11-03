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
    public class BL_SeguroVidaLey
    {
        public SeguroVidaLey SeguroVidaLeyActivo()
        {
            DA_SeguroVidaLey DASeguroVidaLey = new DA_SeguroVidaLey();
            try
            {
                return DASeguroVidaLey.SeguroVidaLeyActiva();
            }
            catch (Exception e)
            {
                EventLogger.EscribirLog(e.Message.ToString());
                throw new Exception(e.Message.ToString());
            }
        }
    }
}
