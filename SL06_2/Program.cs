using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace SL06_2
{
    public class Fruit
    {
        [JsonProperty(PropertyName = "fruit")]
        public string Type { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
    }

    public class Indicator
    {
        public string Id { get; set; }
        public string Value { get; set; }
    }

    public class Country
    {
        public string Id { get; set; }
        public string Value { get; set; }
    }

    public class Statistisc
    {
        public Indicator Indicator { get; set; }
        public Country Country { get; set; }
        public string Value { get; set; }
        public string Decimal { get; set; }
        public string Date { get; set; }
    }


    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<Fruit>();

            //Otwieramy stream pliku sample.txt
            using (var sr = new StreamReader("sample.json"))
            {
                var line = sr.ReadToEnd();

                list = JsonConvert.DeserializeObject<List<Fruit>>(line);
            }

          

        }



    }
}
