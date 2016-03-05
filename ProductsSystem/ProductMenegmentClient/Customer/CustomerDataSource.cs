using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductMenegmentClient
{
    public class CustomerDataSource : ICustomerDataSource
    {
        private readonly ILogger _logger;

        public CustomerDataSource(ILogger logger)
        {
            _logger = logger;
        }

        public void AddCustomer(string customer)
        {
            _logger.Log(customer);
        }
    }
}