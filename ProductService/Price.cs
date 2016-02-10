using System;
using System.Collections.Generic;
using System.Text;


namespace ProductService
{
    public class Price
    {
        private int p_ID = -1;
        private double p_PurchasePrice = 0;
        private double p_SellingPrice = 0;

        public virtual int ID
        {
            get { return p_ID; }
            set { p_ID = value; }
        }

        public virtual double PurchasePrice
        {
            get { return p_PurchasePrice; }
            set { p_PurchasePrice = value; }
        }

        public virtual double SellingPrice
        {
            get { return p_SellingPrice; }
            set { p_SellingPrice = value; }
        }

        public override string ToString()
        {
            return string.Format("ID-{0}:PurchasePrice-{1}:SellingPrice-{2}", p_ID, p_PurchasePrice, p_SellingPrice);
        }

    }
}
