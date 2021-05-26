using ConsoleApp1.Products.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Products
{
    public class ProductRepository
    {
        private readonly BikeStoresEntities _db;

        public ProductRepository(BikeStoresEntities db)
        {
            _db = db;
        }

        public List<ProductDto> GetProducts()
        {

            return _db.products.Select(x => new ProductDto()
            {
                BrandName = x.brand.brand_name,
                CategoryName = x.category.category_name,
                Id = x.product_id,
                Name = x.product_name
            }).ToList();

        }


    }
}
