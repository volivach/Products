using System;
using System.Collections.Generic;
using System.Text;

namespace ProductService

{
    public class Remnants
    {
        private int p_ID = -1;
        private int p_Qty = 0;

        public Remnants()
        {

        }

        public virtual int ID
        {
            get { return p_ID;}
            set { p_ID = value;}
        }

        public virtual int Qty
        {
            get
            {
                    return p_Qty;
            }
            set
            {
                p_Qty = value;
            }
        }

        public override string ToString()
        {
            return string.Format("ID: {0}; Qty: {1}",p_ID,p_Qty);
        }
    }
}
