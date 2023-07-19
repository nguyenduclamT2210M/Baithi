using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baithi
{
    internal class ProductController
    {
        ProductDBContext dBContext;

        public ProductController()
        {
            var studentDbOptions = new DbContextOptionsBuilder<ProductDBContext>()
                  .UseSqlServer("Data Source=LAPTOP-J64NIJ8B\\SQLEXPRESS;Initial Catalog=DemoConnection;Persist Security Info=True;User ID=sa;Password=12345678;Encrypt=False")
                  .Options;
            this.dBContext = new ProductDBContext(studentDbOptions);
        }
        public void ViewAll()
        {
            var product = dBContext.Product.ToList();
            foreach (var item in product)
            {
                Console.WriteLine("{0} {1} {2}", item.ProductId, item.ProductName, item.Price);
            }
        }
        public void CreateNewProducts()
        {
            Console.Write("Enter Product Id : ");
            string? id = Console.ReadLine();
            Console.Write("Enter Product Name : ");
            string? name = Console.ReadLine();
            Console.Write("Price : ");
            int Price = Convert.ToInt32(Console.ReadLine());


            var product = new Product
            {
                ProductId = id,
                ProductName = name,
                Price = Price

            };

            try
            {
                dBContext.Product.Add(product);
                dBContext.SaveChanges();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public void DeleteProducts()
        {
            Console.Write("Enter id: ");
            string? id = Console.ReadLine();
            var product = dBContext.Product.FirstOrDefault(x => x.ProductId  == id);
            if (product != null)
            {
                dBContext.Product.Remove(product);
                dBContext.SaveChanges();
            }
        }
    }
}
