using ProductMenegmentClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductMenegmentClient
{
    public class CustomerPresenter : BasePresenter<ICustomerView>
    {
        private CustomerModel _customerModel;

        public CustomerPresenter(CustomerDataSource someDataSourceService)
        {
        }

        public override void OnViewInitialized()
        {
            _customerModel = new CustomerModel() { CustomerName = "xyz" };
            View.SetCustomerModelAsDataContext(_customerModel);
        }

        public void OnAddCustomer(string customerName)
        {
            //---Business logic
            _customerModel.CustomerName = "Updated Name - " + customerName;
        }

        public override void OnViewFinalize() { }
    }
}