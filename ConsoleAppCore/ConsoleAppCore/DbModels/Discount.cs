using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppCore.DbModels
{
    public class Discount
    {
        public int Id { get; set; }
        public decimal Value { get; set; }

        public string Code { get; set; }
    }
}
