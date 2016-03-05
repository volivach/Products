using NHibernate;
using NHibernate.Cfg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;

namespace ProductService
{

    public class ProductsService : IProductsService
    {
        private ISessionFactory m_SessionFactory = null;
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public double GetProfit()
        {
            double purchCost = 0;
            double sellingCost = 0;
            var sales  = GetSales();
            List<Product> lstProduct = new List<Product>();
            List<ItemSaled> isd = new List<ItemSaled>();
            foreach (Sales s in sales)
                isd.AddRange(s.SalesItems);


            foreach (ItemSaled s in isd)
            {
                purchCost += s.Product.Price.PurchasePrice*s.ProductAmount;
                sellingCost += s.Product.Price.SellingPrice*s.ProductAmount;
            }
                
                return sellingCost-purchCost;
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public void CreateAcceptance(Product p, int Quantity)
        {
            Acceptance ac = new Acceptance();
            ac.ID = -1;
            ac.Quantity = Quantity;
            ac.Product = p;
            p.Remnants.Qty += Quantity;
            UpdateProducts(p);

            AddAcceptance(ac);
        }

        public IList<Acceptance> GetAcceptanceHistory()
        {
            ConfigureNHibernate();
            using (ISession session = m_SessionFactory.OpenSession())
            {
                ICriteria targetObjects = session.CreateCriteria(typeof(Acceptance));
                IList<Acceptance> itemList = targetObjects.List<Acceptance>();

                return itemList;
            }
        }

        public void AddAcceptance(Acceptance ac)
        {
            ConfigureNHibernate();
           // ISession m_Session = m_SessionFactory.OpenSession();
            using (ISession session = m_SessionFactory.OpenSession())
            {
                using (session.BeginTransaction())
                {
                    session.SaveOrUpdate(ac);
                    session.Transaction.Commit();
                }
            }

        }

        public IList<Product> GetProducts()
        {
            ConfigureNHibernate();
            using (ISession session = m_SessionFactory.OpenSession())
            {
                ICriteria targetObjects = session.CreateCriteria(typeof(Product));
                IList<Product> itemList = targetObjects.List<Product>();

                return itemList;
            }
         }

        public void AddProducts(Product product)
                {
                    ConfigureNHibernate();
                    using (ISession session = m_SessionFactory.OpenSession())
                    {
                        using (session.BeginTransaction())
                        {
                            session.SaveOrUpdate(product);
                            session.Transaction.Commit();
                        }
                    }

                }

        public void UpdateProducts(Product p)
        {
            {
                ConfigureNHibernate();
                using (ISession session = m_SessionFactory.OpenSession())
                {
                    using (session.BeginTransaction())
                    {
                        
                        session.Update(p);
                        session.Transaction.Commit();
                    }
                }

            }
        }

        public void AddOrder(Customer c, ItemForSale[] lst)
        {
            Order tmpOrder = new Order();
            tmpOrder.Customer = c;
            tmpOrder.Date = DateTime.Now;
            tmpOrder.ID = -1;
            tmpOrder.OrdersProduct = lst;

            ConfigureNHibernate();
            using (ISession session = m_SessionFactory.OpenSession())
            {
                using (session.BeginTransaction())
                {
                    session.SaveOrUpdate(tmpOrder);
                    session.Transaction.Commit();
                }
            }

        }

        public IList<Order> GetOrders()
        {

            ConfigureNHibernate();
            using (ISession session = m_SessionFactory.OpenSession())
            {
                ICriteria targetObjects = session.CreateCriteria(typeof(Order));
                IList<Order> itemList = targetObjects.List<Order>();
                return itemList;
            }
        }

        public void DeleteOrder(Order ord)
        {
            ConfigureNHibernate();
            using (ISession session = m_SessionFactory.OpenSession())
            {
                using (session.BeginTransaction())
                {
                    session.Delete(ord);
                    session.Transaction.Commit();
                }
            }
        }

        public IList<Customer> GetCustomers()
        {
            Thread.Sleep(5000);
            ConfigureNHibernate();
            using (ISession session = m_SessionFactory.OpenSession())
            {
                // Retrieve all objects of the type passed in
                ICriteria targetObjects = session.CreateCriteria(typeof(Customer));
                IList<Customer> itemList = targetObjects.List<Customer>();

                IList<Order> tmp = new List<Order>();
                tmp = GetOrders();
                for (int i = 0; i < itemList.Count; i++)
                    for (int j = 0; j < tmp.Count; j++)
                        if (itemList[i].ID == tmp[j].Customer.ID)
                            itemList[i].Orders.Add(tmp[j]);

                // Set return value
                return itemList;
            }
        
        }

        public void AddCustomer(Customer customer)
        {
            ConfigureNHibernate();
            using (ISession session = m_SessionFactory.OpenSession())
            {
                using (session.BeginTransaction())
                {
                    session.SaveOrUpdate(customer);
                    session.Transaction.Commit();
                }
            }

        }

        public IList<Provider> GetProviders()
        {
            ConfigureNHibernate();
            using (ISession session = m_SessionFactory.OpenSession())
            {
                // Retrieve all objects of the type passed in
                ICriteria targetObjects = session.CreateCriteria(typeof(Provider));
                IList<Provider> itemList = targetObjects.List<Provider>();

                // Set return value
                return itemList;
            }
        }

        public void AddProvider(Provider provider)
        {

            ConfigureNHibernate();
            using (ISession session = m_SessionFactory.OpenSession())
            {
                using (session.BeginTransaction())
                {
                    session.SaveOrUpdate(provider);
                    session.Transaction.Commit();
                }
            }
        }

        public Address GetAddress(Customer c)
        {
            return c.Address;
        }

        public IList<Manufacturer> GetManufacturers()
        {
            ConfigureNHibernate();
            using (ISession session = m_SessionFactory.OpenSession())
            {
                // Retrieve all objects of the type passed in
                ICriteria targetObjects = session.CreateCriteria(typeof(Manufacturer));
                IList<Manufacturer> itemList = targetObjects.List<Manufacturer>();

                // Set return value
                return itemList;
            }
        }

        public void AddManufacturer(Manufacturer manufacturer)
        {

            ConfigureNHibernate();
            using (ISession session = m_SessionFactory.OpenSession())
            {
                using (session.BeginTransaction())
                {
                    session.SaveOrUpdate(manufacturer);
                    session.Transaction.Commit();
                }
            }
        }

        public IList<Sales> GetSales()
        {
            ConfigureNHibernate();
            using (ISession session = m_SessionFactory.OpenSession())
            {
                ICriteria targetObjects = session.CreateCriteria(typeof(Sales));
                IList<Sales> itemList = targetObjects.List<Sales>();
                return itemList;
            }
        }

        public void MakeSales(Order order)
        {
            //Создаем запись продажи на основе заказа
            Sales sl = new Sales();
            sl.ID = -1;
            sl.Date = DateTime.Now;
            sl.Customer = order.Customer;

            //Формируем список проданых товаров, общую сумму продажи , обновляем остатки товара на складе
            foreach (ItemForSale ifs in order.OrdersProduct)
            {
                ItemSaled isd = new ItemSaled();
                isd.ID = -1;
                isd.Product = ifs.Product;
                isd.ProductAmount = ifs.ProductAmount;
                sl.SalesItems.Add(isd);
                sl.TotalPrice = isd.Product.Price.SellingPrice*isd.ProductAmount;
                isd.Product.Remnants.Qty -= ifs.ProductAmount;
                SaveItemSaled(isd);
                UpdateProducts(isd.Product);
            }

            //Сохраняем в базе нашу продажу и удаляем заказ
            AddSales(sl);
            //Удаляем записи с таблици "ItemForSale для данного заказа"
            foreach (ItemForSale ifs in order.OrdersProduct)
                DeleteItemForSale(ifs);
            DeleteOrder(order);

           
            
        }

        public void AddSales(Sales s)
        {
            ConfigureNHibernate();
            using (ISession session = m_SessionFactory.OpenSession())
            {
                using (session.BeginTransaction())
                {
                    session.SaveOrUpdate(s);
                    session.Transaction.Commit();
                }
            }
        }

        public void SaveItemSaled(ItemSaled i)
        {
            ConfigureNHibernate();
            using (ISession session = m_SessionFactory.OpenSession())
            {
                using (session.BeginTransaction())
                {
                    session.Save(i);
                    session.Transaction.Commit();
                }
            }
        }

        public void DeleteItemForSale(ItemForSale i)
        {
            ConfigureNHibernate();
            using (ISession session = m_SessionFactory.OpenSession())
            {
                using (session.BeginTransaction())
                {
                    session.Delete(i);
                    session.Transaction.Commit();
                }
            }
        }

        public IList<ProductType> GetTypes()
        {
            ConfigureNHibernate();
            using (ISession session = m_SessionFactory.OpenSession())
            {
                ICriteria targetObjects = session.CreateCriteria(typeof(ProductType));
                IList<ProductType> itemList = targetObjects.List<ProductType>();
                return itemList;
            }
        }

        public void AddNewType(ProductType pType)
        {
            ConfigureNHibernate();
            using (ISession session = m_SessionFactory.OpenSession())
            {
                using (session.BeginTransaction())
                {
                    session.SaveOrUpdate(pType);
                    session.Transaction.Commit();
                }
            }
        }

        private void ConfigureNHibernate()
    {
        Configuration cfg = new Configuration();
        cfg.Configure();
        Assembly thisAssembly = typeof(Customer).Assembly;
        cfg.AddAssembly(thisAssembly);
        m_SessionFactory = cfg.BuildSessionFactory();
    }
    }
}
