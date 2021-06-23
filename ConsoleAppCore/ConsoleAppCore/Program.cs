using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsoleAppCore.DbModels;
using Microsoft.EntityFrameworkCore;

namespace ConsoleAppCore
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {


                var products = await GetProductDtos(DateTime.Today);
            }
            catch (Exception)
            {

                throw;
            }

            //Coffee cup = PourCoffee();
            //Console.WriteLine("coffee is ready");

            //Task<Egg> eggsTask = FryEggsAsync(2);
            //Task<Bacon> baconTask = FryBaconAsync(3);
            //var toastTask = MakeToastWithButterAndJamAsync(2);

            //var breakfastTasks = new List<Task> { eggsTask, baconTask, toastTask };

            //while (breakfastTasks.Count > 0)
            //{
            //    Task finishedTask = await Task.WhenAny(breakfastTasks);
            //    if (finishedTask == eggsTask)
            //    {
            //        Console.WriteLine("eggs are ready");
            //    }
            //    else if (finishedTask == baconTask)
            //    {
            //        Console.WriteLine("bacon is ready");
            //    }
            //    else if (finishedTask == toastTask)
            //    {
            //        Console.WriteLine("toast is ready");
            //    }
            //    breakfastTasks.Remove(finishedTask);
            //}


            Console.ReadLine();
        }

        static async Task<Toast> MakeToastWithButterAndJamAsync(int number)
        {
            var toast = await ToastBreadAsync(number);
            ApplyButter(toast);
            ApplyJam(toast);

            return toast;
        }

        private static Juice PourOJ()
        {
            Console.WriteLine("Pouring orange juice");
            return new Juice();
        }

        private static void ApplyJam(Toast toast) =>
            Console.WriteLine("Putting jam on the toast");

        private static void ApplyButter(Toast toast) =>
            Console.WriteLine("Putting butter on the toast");

        private static async Task<Toast> ToastBreadAsync(int slices)
        {
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("Putting a slice of bread in the toaster");
            }
            Console.WriteLine("Start toasting...");
            await Task.Delay(3000);
            Console.WriteLine("Remove toast from toaster");

            return new Toast();
        }

        private static async Task<Bacon> FryBaconAsync(int slices)
        {
            Console.WriteLine($"putting {slices} slices of bacon in the pan");
            Console.WriteLine("cooking first side of bacon...");
            await Task.Delay(3000);
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("flipping a slice of bacon");
            }
            Console.WriteLine("cooking the second side of bacon...");
            await Task.Delay(3000);
            Console.WriteLine("Put bacon on plate");

            return new Bacon();
        }

        private static async Task<Egg> FryEggsAsync(int howMany)
        {
            Console.WriteLine("Warming the egg pan...");
            await Task.Delay(3000);
            Console.WriteLine($"cracking {howMany} eggs");
            Console.WriteLine("cooking the eggs ...");
            await Task.Delay(3000);
            Console.WriteLine("Put eggs on plate");

            return new Egg();
        }

        private static Coffee PourCoffee()
        {
            Console.WriteLine("Pouring coffee");
            return new Coffee();
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

        static Task<List<Discount>> GetDiscountsAsync(DateTime date)
        {
            try
            {


                using (var db = new BikeStoresContext())
                {
                    return db.Discounts.Where(x => x.DateFrom >= date && x.DateTo <= date).ToListAsync();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        static Task<List<Product>> GetProductsAsync(DateTime date)
        {
            try
            {


                using (var db = new BikeStoresContext())
                {
                    return db.Products.ToListAsync();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        static async Task<List<ProductDto>> GetProductDtos(DateTime date)
        {
            using (var db = new BikeStoresContext())
            {
                var disconts = await db.Discounts.Where(x => x.DateFrom >= date && x.DateTo <= date).ToListAsync();

                var products = await db.Products.ToListAsync();
     
                return products.Select(p =>
               {
                   var dto = new ProductDto()
                   {
                       Name = p.ProductName
                   };

                   if (disconts.Any(d => d.ProductId == p.ProductId || d.BrandId == p.BrandId || d.CategoryId == p.CategoryId))
                   {
                       if (disconts.Any(d => d.ProductId == p.ProductId))
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
