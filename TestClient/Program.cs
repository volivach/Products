using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestClient.ProductService;


namespace TestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new ProductsServiceClient();

            //foreach (Order o in client.GetOrders())
            //    Console.WriteLine(o.ID);
            //client.MakeSales(client.GetOrders()[0]);



            //ItemForSale ifs = new ItemForSale();
            //ifs.ID = -1;
            //ifs.ProductAmount = 20;
            //ifs.Product = client.GetProducts()[3];
            //ItemForSale[] i = new ItemForSale[1];
            //i[0] = ifs;
            //client.AddOrder(client.GetCustomers()[0], i);


            Console.ReadLine();
        }
    }
}
