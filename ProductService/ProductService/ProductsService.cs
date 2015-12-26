using System;
using Nhibernate;
using Nhibernate.Cfg;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ProductService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class ProductsService : IProductsService
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
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

    /// <summary>
    /// Configures NHibernate and creates a member-level session factory.
    /// </summary>
    private void ConfigureNHibernate()
    {
        // Initialize
        Configuration cfg = new Configuration();
        cfg.Configure();

        /* Note: The AddAssembly() method requires that mappings be 
         * contained in hbm.xml files whose BuildAction properties 
          are set to ‘Embedded Resource’. */

        // Add class mappings to configuration object
        Assembly thisAssembly = typeof(Product).Assembly;
        cfg.AddAssembly(thisAssembly);

        // Create session factory from configuration object
        m_SessionFactory = cfg.BuildSessionFactory();
    }
         public List<string> GetProducts()
        {
            ConfigureNHibernate();
            ISession m_Session = m_SessionFactory.OpenSession();

            // Retrieve all objects of the type passed in
            ICriteria targetObjects = m_Session.CreateCriteria(typeof(Product));
            IList<Product> itemList = targetObjects.List<Product>();

            List<string> strProducts = new List<string>();
            foreach (var it in itemList)
            {
                strProducts.Add(it.ToString());
            }

            m_Session.Close();
            m_Session.Dispose();

            // Set return value
            return strProducts;

            //return new List<string>(){ "LG-101", "Think Pad t440s", "iPhone 6s" };
         }
    }
}
