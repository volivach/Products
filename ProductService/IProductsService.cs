using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ProductService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IProductsService
    {
        [OperationContract]
        string GetData(int value);

        [OperationContract]
        IList<Product> GetProducts();

        [OperationContract]
        double GetProfit();

        [OperationContract]
        void UpdateProducts(Product p);

        [OperationContract]
        void AddProducts(Product product);

        [OperationContract]
        void AddCustomer(Customer customer);

        [OperationContract]
        void DeleteOrder(Order ord);

        [OperationContract]
        IList<Sales> GetSales();

        [OperationContract]
        void MakeSales(Order o);

        [OperationContract]
        Address GetAddress(Customer c);

        [OperationContract]
        IList<Customer> GetCustomers();

        [OperationContract]
        IList<Provider> GetProviders();

        [OperationContract]
        void AddProvider(Provider provider);

        [OperationContract]
        IList<Manufacturer> GetManufacturers();

        [OperationContract]
        void AddManufacturer(Manufacturer manufacturer);

        [OperationContract]
        IList<Order> GetOrders();

        [OperationContract]
        void AddOrder(Customer c, ItemForSale[] lst);


        [OperationContract]
        void CreateAcceptance(Product p, int Quantity);

        [OperationContract]
        IList<Acceptance> GetAcceptanceHistory();

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        [OperationContract]
        IList<ProductType> GetTypes();

        [OperationContract]
        void AddNewType(ProductType p);

        void AddSales(Sales s);
        void AddAcceptance(Acceptance ac);
        void SaveItemSaled(ItemSaled i);
        void DeleteItemForSale(ItemForSale i);


        
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "ProductService.ContractType".
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
