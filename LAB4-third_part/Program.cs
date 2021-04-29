using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace LAB4_third_part
{
    public interface IPersonRepository
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        int PersonAge { get; set; }
    }

    public class FilePersonRepository : IPersonRepository
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PersonAge { get; set; }

        public static void SerializeRepo(List<FilePersonRepository> list)
        {
            using (var sw = new StreamWriter("personRepo.json"))
            {
                var json = JsonConvert.SerializeObject(list, Formatting.Indented);

                sw.WriteLine(json);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var personRepositories = new List<IPersonRepository>();

            personRepositories.Add(new FilePersonRepository()
            { 
                FirstName = "Jan",
                LastName = "Kowalski",
                PersonAge = 22
            });

            personRepositories.Add(new FilePersonRepository()
            { 
                FirstName = "Anna", 
                LastName = "Pazdan", 
                PersonAge = 19 
            });

            personRepositories.Add(new FilePersonRepository()
            { 
                FirstName = "Marcin", 
                LastName = "Chmiel", 
                PersonAge = 23 
            });
        }
    }
}
