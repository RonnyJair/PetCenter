using PetCenter.Common.Core.Entities;
using PetCenter.Common.Core.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetCenter.Infrastucture.Data
{
    public class DA_Uit
    {
        public Uit UitActiva()
        {
            using (BdPetCenterEntities1 contexto = new BdPetCenterEntities1())
            {
                Uit item = (from x in contexto.Uits
                                 where x.Estado == true
                                 select x).ToList().First();

                return item;
            }
        }
    }
}
