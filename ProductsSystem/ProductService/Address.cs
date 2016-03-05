using System;
using System.Collections.Generic;
using System.Text;


namespace ProductService
{
    public class Address
    {
        private int p_ID = -1;
        private string p_City = String.Empty;
        private string p_State = String.Empty;
        private string p_Street = String.Empty;
        private string p_Zip = string.Empty;

        public virtual string City
        {
            get { return p_City; }
            set { p_City = value; }
        }

        public virtual string Street
        {
            get { return p_Street; }
            set { p_Street = value; }
        }

        public virtual string State
        {
            get { return p_State; }
            set { p_State = value; }
        }

        public virtual string ZIP
        {
            get { return p_Zip; }
            set { p_Zip = value; }
        }

        public virtual int ID
        {
            get
            {
                return p_ID;
            }

            set
            {
                p_ID = value;
            }
        }

        public override string ToString()
        {
            return string.Format("{0}:{1}:{2}", p_City, p_Street, p_Zip);
        }
    }
}
