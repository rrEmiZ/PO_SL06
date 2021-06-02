using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ConsoleAppCore.DbModels
{
    public class Discount
    {
        public int Id { get; set; }
        public decimal DicountProcent { get; set; }

        public string Code { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }
        public int? ProductId { get; set; }

        [ForeignKey(nameof(BrandId))]
        public Brand Brand { get; set; }
        public int? BrandId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }
        public int? CategoryId { get; set; }

        public DateTime DateFrom { get; set; }

        public DateTime DateTo { get; set; }

    }
}
