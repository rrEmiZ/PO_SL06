using System;
using System.Linq;
using ConsoleAppCore.DbModels;

namespace ConsoleAppCore
{
    class Program
    {
        static void Main(string[] args)
        {

            using(var db = new BikeStoresContext())
            {
                //var items = db.Brands.ToList();

                //var first = items.FirstOrDefault();

                //first.BrandName += "Test";

                //db.Update(first);

                //db.SaveChanges();

                //db.Discounts.Add(new Discount() { Value = 2, Code = "TEST"});

                //db.SaveChanges();


                using(var trans = db.Database.BeginTransaction())
                {
                    var brand = new Brand()
                    {
                        BrandName = "Testtt"
                    };

                    db.Brands.Add(brand);
                    db.SaveChanges();


                    var prod = new Product()
                    {
                        BrandId = brand.BrandId,
                        ProductName = "tet",
                        CategoryId = 1,
                        ListPrice = 4,
                        ModelYear = 2000
                    };

                    db.Products.Add(prod);

                    db.SaveChanges();


                    trans.Commit();
                }



            }
            
            Console.ReadLine();
        }
    }
}
