// Zadanie 5

using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Zadanie5_w61920
{

    public interface IPersonRepository
    {
        string FName { get; set; }
        string LName { get; set; }

        void GetAllFNames();
    }

    public class FilePersonRepository : IPersonRepository
    {
        public string FName { get; set; }
        public string LName { get; set; }

        public void GetAllFNames()
        {
            var list = new List<FilePersonRepository>();
            using (var sr = new StreamReader("people.json"))
            {
                var line = sr.ReadToEnd();
                list = JsonConvert.DeserializeObject < List<FilePersonRepository>>(line);
            }

            foreach(var item in list) Console.WriteLine(item.FName);
        }
    }
    class Program
    {
        
        static void Main(string[] args)
        {
            FilePersonRepository Obj1 = new FilePersonRepository();
            Obj1.GetAllFNames();
        }
    }
}
