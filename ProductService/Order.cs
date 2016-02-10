using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ProductService
{
    public class Order
    {

        private Customer p_Customer;
        private DateTime p_Date = DateTime.Today;
        private int p_ID = -1;
        private IList<ItemForSale> p_Orders = new List<ItemForSale>();

        public Order()
        {
        }

        public virtual Customer Customer
        {
            get { return p_Customer; }
            set { p_Customer = value; }
        }

         public virtual DateTime Date
        {
            get { return p_Date; }
            set { p_Date = value; }
        }

        public virtual int ID
        {
            get { return p_ID; }
            set { p_ID = value; }
        }

        public virtual IList<ItemForSale> OrdersProduct
        {
            get { return p_Orders; }
            set { p_Orders = value; }
        }

        public override string ToString()
        {
            return String.Format("{0} {1}, {2}", p_Customer.Name, p_ID, p_Date.ToString());
        }
    }
}
