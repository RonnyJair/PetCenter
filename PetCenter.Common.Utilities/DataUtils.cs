using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Reflection;
using System.Reflection.Emit;
using System.ComponentModel;

namespace PetCenter.Common.Utilities
{
    public class DataUtils
    {

        public  DataTable ToDataTable<T>( IList<T> data)
        {
            PropertyDescriptorCollection props =
                TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            try
            {
                for (int i = 0; i < props.Count; i++)
                {
                    PropertyDescriptor prop = props[i];
                    table.Columns.Add(prop.Name);
                }
                object[] values = new object[props.Count];
                foreach (T item in data)
                {
                    for (int i = 0; i < values.Length; i++)
                    {
                        values[i] = props[i].GetValue(item);
                    }
                    table.Rows.Add(values);
                }
            }
            catch (Exception ex) {
                EventLogger.EscribirLog(ex.ToString());
            }
            return table;
        }

    }
}