using ConsoleApp1.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {


            using (var db = new BikeStoresEntities())
            {
                //var repo = new ProductRepository(db);


                //var products = repo.GetProducts();

                //foreach (var item in products)
                //{
                //    Console.WriteLine($"{item.Id} - {item.Name} - {item.CategoryName} - {item.BrandName}");
                //}

                //CREATE
                //db.brands.Add(new brand()
                //{
                //    brand_name = "test"
                //});

                //UPDATE
                //var brand = db.brands.FirstOrDefault(x => x.brand_id == 10);

                //brand.brand_name = "TESTTTTTT";

                //DELETE
                //var brand = db.brands.FirstOrDefault(x => x.brand_id == 10);

                //db.brands.Remove(brand);

                db.SaveChanges();

            }
        }
    }
}
