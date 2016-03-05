using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Data;
using ProductMenegmentClient.ProductService;

namespace ProductMenegmentClient
{
    public class CustomerModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ICollectionView Customers { get; set; }

        public CustomerModel()
        {
          Initialize();
        }

        private async void Initialize()
        {
            var client = new ProductsServiceClient();

            var customersFromProduct = await client.GetCustomersAsync();
            lock (this)
            {

                var _customers = new List<Customer>();
                foreach (var it in customersFromProduct)
                {
                    Customer cur = new Customer();
                    cur.Name = it.Name;
                    Address address = it.Address;
                    cur.Address = string.Format("{0} {1} {2}", address.State, address.City, address.Street);
                    _customers.Add(cur);
                }

                Customers = CollectionViewSource.GetDefaultView(_customers);
                PropertyChanged(this, new PropertyChangedEventArgs("Customers"));

            }
        }

        private string _customerName;
        public string CustomerName
        {
            get { return _customerName; }
            set
            {
                _customerName = value;
                OnPropertyChanged("CustomerName");
            }
        }



        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private class Customer
        {
            public string Name { get; internal set; }
            public string Address { get; internal set; }
        }
    }
}