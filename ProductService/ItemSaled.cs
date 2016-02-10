using System;
using System.Collections.Generic;
using System.Text;


namespace ProductService
{

    public class ItemSaled
    {
        private int p_ID = -1;
        private Product p_Product = new Product();
        private int p_ProductAmount = 0;

        public virtual Product Product
        {
            get { return p_Product; }
            set { p_Product = value; }
        }

        public virtual int ProductAmount
        {
            get { return p_ProductAmount; }
            set { p_ProductAmount = value; }
        }

        public virtual int ID
        {
            get { return p_ID; }
            set { p_ID = value; }
        }
    }
}
