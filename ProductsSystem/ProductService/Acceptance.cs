using System;
using System.Collections.Generic;
using System.Text;

namespace ProductService

{
    public class Acceptance
    {
        private int p_ID = -1;
        private DateTime p_Date = DateTime.Now;
        private Product p_Product = new Product();
        private int p_Quantity = 0;
        public Acceptance()
        {

        }

        public virtual int ID
        {
            get { return p_ID;}
            set { p_ID = value;}
        }

        public virtual int Quantity
        {
            get
            {
                return p_Quantity;
            }

            set
            {
                p_Quantity = value;
            }
        }

        public virtual DateTime Date
        {
            get
            {
                return p_Date;
            }

            set
            {
                p_Date = value;
            }
        }

        public virtual Product Product
        {
            get
            {
                return p_Product;
            }

            set
            {
                p_Product = value;
            }
        }

        public override string ToString()
        {
            return string.Format("ID: {0} | DATE: {1} | PRODUCT: {2} | QTY: {3}",ID,Date,Product,Quantity);
        }


    }
}
