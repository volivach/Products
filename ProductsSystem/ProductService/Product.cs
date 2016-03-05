using System;
using System.Collections.Generic;
using System.Text;

namespace ProductService
{

    public class Product
    {
        private Remnants p_Remnants = new Remnants();
        private Provider p_Provider = new Provider();
        private Price p_Price = new Price();
        private Manufacturer p_Manufacturer = new Manufacturer();
        private ProductType p_productType = new ProductType();
        private int p_ID = -1;
        private string p_Name = String.Empty;

        public Product()
        {
        }

        public virtual int ID
        {
            get { return p_ID; }
            set { p_ID = value; }
        }

        public virtual ProductType productType
        {
            get { return p_productType; }
            set { p_productType = value; }
        }

        public virtual Provider Provider
        {
            get { return p_Provider; }
            set { p_Provider = value; }
        }

        public virtual Manufacturer Manufacturer
        {
            get { return p_Manufacturer; }
            set { p_Manufacturer = value; }
        }

        public virtual Price Price
        {
            get { return p_Price; }
            set { p_Price = value; }
        }

        public virtual string Name
        {
            get { return p_Name; }
            set { p_Name = value; }
        }

        public virtual Remnants Remnants
        {
            get{return p_Remnants;}
            set{p_Remnants = value;}
        }

        public override string ToString()
        {
            return p_Name;
        }

    }
}
