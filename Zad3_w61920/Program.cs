// Zadanie 3
using System;
using System.IO;

namespace Zadanie3_w61920
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter = 0;
            using (var sr = new StreamReader("pesels.txt"))
            {
                var line = sr.ReadLine();
                
                while (line != null)
                {
                    
                    
                    if (line[10]%2 == 0)
                    {
                        counter++;
                    }
                    line = sr.ReadLine();
                    
                }
                Console.WriteLine("Liczba zenskich peseli: " + counter);    
            }
        }
    }
}
