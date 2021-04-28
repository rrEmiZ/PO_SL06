using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace SL06_2
{
    public class SL06Exception : ApplicationException
    {
        public int Liczba { get; set; }

        public SL06Exception(string message, int liczba) : base(message) => Liczba = liczba;

    }

    class Program
    {
        static void Main(string[] args)
        {
            //Testowy issue rozwiaznie
            int x = Convert.ToInt32(Console.ReadLine());
            try
            {
                if (x == 0)
                    throw new NullReferenceException("Błędna liczba");

                int y = 100 / x;
            }
            catch (SL06Exception e)
            {
                Console.WriteLine($"{e.Message}, podana liczba to {e.Liczba}");
            }
            catch (ArithmeticException e)
            {
                Console.WriteLine($"ArithmeticException Handler: {e}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Generic Exception Handler: {e}");
            }

            var zmienna1 = string.Empty;
            try
            {
                SomeFunc();
            }
            catch (Exception e)
            {
                zmienna1 = e.Message;
            }


            Console.ReadLine();
        }

        static string SomeFunc()
        {

            throw new Exception("jakis string");

        }


    }
}
