using System;
using System.Collections.Generic;
using System.Text;

namespace ProductService

{

    public class ProductType
    {
        private int p_ID = -1;
        private string p_Type = "[New Type]";

        public ProductType()
        {

        }

        public virtual int ID
        {
            get { return p_ID;}
            set { p_ID = value;}
        }

        public virtual string Type
        {
            get { return p_Type; }
            set { p_Type = value; }
        }

        public override string ToString()
        {
            return p_Type;
        }
    }
}
