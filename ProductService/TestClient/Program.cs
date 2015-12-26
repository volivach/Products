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

            foreach (var it in client.GetProducts())
            {
                Console.WriteLine(it);
            }

            Console.ReadLine();
        }
    }
}
