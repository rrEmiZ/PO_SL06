using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleAppCore.DbModels;

namespace ConsoleAppCore
{
    class Program
    {
     

            static void Main(string[] args)
            {
                var wallet = new Wallet(200);
                ReflectionWriteProperties(wallet);
                Console.ReadLine();

            }

            public static void ReflectionWriteProperties(object obj)
            {
                var type = obj.GetType();

                var fields = type.GetFields();

                foreach (var field in fields)
                {
                    Console.WriteLine($"Field: {field.Name} - Value: {field.GetValue(obj)}");
                }

                var properties = type.GetProperties();

                foreach (var prop in properties)
                {
                    Console.WriteLine($"Property: {prop.Name} - Value: {prop.GetValue(obj)}");
                }
            }

        //static void Main(string[] args)
        //{
        //    using (var db = new BikeStoresContext())
        //    {
        //        //var items = db.Brands.ToList();

        //        //var first = items.FirstOrDefault();

        //        //first.BrandName += "Test";

        //        //db.Update(first);

        //        //db.SaveChanges();

        //        //db.Discounts.Add(new Discount() { Value = 2, Code = "TEST"});

        //        //db.SaveChanges();


        //        using (var trans = db.Database.BeginTransaction())
        //        {
        //            var brand = new Brand()
        //            {
        //                BrandName = "Testtt"
        //            };

        //            db.Brands.Add(brand);
        //            db.SaveChanges();


        //            var prod = new Product()
        //            {
        //                BrandId = brand.BrandId,
        //                ProductName = "tet",
        //                CategoryId = 1,
        //                ListPrice = 4,
        //                ModelYear = 2000
        //            };

        //            db.Products.Add(prod);

        //            db.SaveChanges();


        //            trans.Commit();
        //        }


        //        var products = db.Products.ToList();



        //    }

        //    Console.ReadLine();
        //}

        static List<ProductDto> GetProducts(DateTime date)
        {
            using (var db = new BikeStoresContext())
            {
                var disconts = db.Discounts.Where(x => x.DateFrom >= date && x.DateTo <= date).ToList();

                var products = db.Products.ToList();


                return products.Select(p =>
               {
                   var dto = new ProductDto()
                   {
                       Name = p.ProductName
                   };

                   if (disconts.Any(d => d.ProductId == p.ProductId || d.BrandId == p.BrandId || d.CategoryId == p.CategoryId))
                   {
                       if(disconts.Any(d => d.ProductId == p.ProductId))
                       {
                           var discount = disconts.FirstOrDefault(d => d.ProductId == p.ProductId);

                           dto.Price = p.ListPrice - (p.ListPrice * discount.DicountProcent);
                       }

                       //Brand ..


                       //Category..
                   }


                   return dto;
               }).ToList();              


            }
        }

    }
}
