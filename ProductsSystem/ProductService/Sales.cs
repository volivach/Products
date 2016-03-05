using System;
using System.Collections.Generic;
using System.Text;

namespace ProductService

{

    public class Sales
    {
        private int p_ID = -1;
        private DateTime p_Date;
        Customer p_Customer = new Customer();
        private IList<ItemSaled> p_SalesItems = new List<ItemSaled>();
        private double p_TotalPrice = 0;

        public Sales()
        {

        }

        public virtual int ID
        {
            get { return p_ID; }
            set { p_ID = value; }
        }

        public virtual DateTime Date
        {
            get { return p_Date; }
            set { p_Date = value; }
        }

        public virtual Customer Customer
        {
            get { return p_Customer; }
            set { p_Customer = value; }
        }

        public virtual IList<ItemSaled> SalesItems
        {
            get { return p_SalesItems; }
            set { p_SalesItems = value; }
        }

        public virtual double TotalPrice
        {
            get { return p_TotalPrice; }
            set { p_TotalPrice = value; }
        }
    }
}
