using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Omadiko.RepositoryServices;
using Omadiko.Entities;

namespace Omadiko.Console2
{
    class Program
    {
        static void Main(string[] args)
        {
            //ProductRepository repo = new ProductRepository();

            //Product p = new Product() { Name = "Lakis", Price = 50000 };

            //repo.Insert(p);

            //foreach (var item in repo.GetAll())
            //{
            //    Console.WriteLine(item.Name);
            //}

            CustomerRepository repo1 = new CustomerRepository();


            foreach (var item in repo1.GetAll())
            {
                Console.WriteLine(item.FirstName + " " + item.LastName);
            }


            //foreach (var item in repo.FilterByName("a"))
            //{
            //    Console.WriteLine(item.Name);
            //}

            
        }
    }
}
