using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductMenegmentClient
{
    public interface ICustomerView
    {
        void SetCustomerModelAsDataContext(CustomerModel customerModel);
    }
}