using System;
using System.Collections.Generic;
using System.Text;

namespace ProductService

{
    public class Account
    {

        private int p_ID = -1;
        private string p_Name = "[New Account]";
        private IList<Order> p_AllOrdersInAccount = new List<Order>();

        public Account()
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

        public virtual IList<Order> AllOrdersInAccount
        {
            get { return p_AllOrdersInAccount; }
            set { p_AllOrdersInAccount = value; }
        }

        public override string ToString()
        {
            return p_Name;
        }

    }
}
