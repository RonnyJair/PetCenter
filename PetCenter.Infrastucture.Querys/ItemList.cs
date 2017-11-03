using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetCenter.Infrastucture.Querys
{
    public class ItemList
    {
        private object m_Value;
        private String m_Descripcion;
        private bool m_Selected;

        public ItemList()
        {
            m_Value = String.Empty;
            m_Descripcion = String.Empty;
            m_Selected = false;
        }

        public ItemList(Object Value, string Descripcion)
        {
            m_Value = Value;
            m_Descripcion = Descripcion;
            m_Selected = false;

        }
        public ItemList(Object Value, string Descripcion, bool Selected)
        {
            m_Value = Value;
            m_Descripcion = Descripcion;
            m_Selected = Selected;

        }



        public bool Selected
        {
            get { return m_Selected; }
            set { m_Selected = value; }
        }

        public virtual bool IsSelected
        {
            get { return m_Selected; }
        }

        public string Descripcion
        {
            get
            {
                return m_Descripcion;
            }
            set
            {
                m_Descripcion = value;
            }
        }

        public object Value
        {
            get
            {
                return m_Value;
            }
            set
            {
                m_Value = value;
                object oldValue = m_Value;
                if (oldValue == value) return;
                m_Value = value;
            }
        }
    }
}
