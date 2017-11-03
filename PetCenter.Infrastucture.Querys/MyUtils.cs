using System;
using System.Collections.Generic;
using System.ComponentModel;
namespace PetCenter.Infrastucture.Querys
{
    public static class MyUtils
    {

        public static List<ItemList> GetEstadoCivil()
        {
            List<ItemList> items = new List<ItemList>();

            items.Add(new ItemList(EstadoCivilEnum.Soltero, "Soltero"));
            items.Add(new ItemList(EstadoCivilEnum.Casado, "Casado"));

            return items;
        }

    }

    [Flags]
    public enum EstadoCivilEnum
    {
        [Description("Solero")]
        Soltero = 0,
        [Description("Casado")]
        Casado = 1
    }
}
