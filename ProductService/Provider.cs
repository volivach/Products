using System;
using System.Collections.Generic;
using System.Text;

namespace ProductService

{
    public class Provider
    {

        private int p_ID = -1;
        private string p_Name = "[New Provider]";

        public Provider()
        {

        }

        public virtual int ID
        {
            get { return p_ID;}
            set { p_ID = value;}
        }

        public virtual string Name
        {
            get { return p_Name; }
            set { p_Name = value; }
        }

        public override string ToString()
        {
            return p_Name;
        }
    }
}
