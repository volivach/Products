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
            var obj = new Product() { ID =-1, Name = "iPhone 4" };
            client.AddProduct(obj);
            
            foreach (var it in client.GetProducts())
            {
                Console.WriteLine(it.Name + it.ID);
            }

            Console.ReadLine();
        }
    }
}
