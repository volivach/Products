using System;
using System.Collections.Generic;
using System.Text;

namespace ProductService

{

    public class Customer
    {
        private Address p_Address = new Address();
        private int p_ID = -1;
        private string p_Name = "[New Customer]";
        private List<Order> p_Orders = new List<Order>();

        public Customer()
        {

        }

        public virtual Address Address
        {
            get { return p_Address; }
            set { p_Address = value; }
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

        public virtual List<Order> Orders
        {
            get { return p_Orders; }
            set { p_Orders = value; }
        }

        public override string ToString()
        {
            return p_Name;
        }
    }
}
