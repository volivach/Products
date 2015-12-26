using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestClient.ProductsService;

namespace TestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new iProductServiceClient();

            foreach (var it in client.GetProducts())
            {
                Console.WriteLine(it);
            }

            Console.ReadLine();
        }
    }
}
