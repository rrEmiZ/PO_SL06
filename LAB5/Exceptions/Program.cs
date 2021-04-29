using System;
using System.Diagnostics;

namespace Exceptions
{
    class Program
    {
        public static int WordLength(string word)
        {
            var wordLength = word.Length;
            return wordLength;
        }

        static void Main(string[] args)
        {
            try
            {
                WordLength(null);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Message = {0}", ex.Message);
                Console.WriteLine("Source = {0}", ex.Source);
                Console.WriteLine("StackTrace:\n{0}", ex.StackTrace);
                Console.WriteLine("TargetSite = {0}", ex.TargetSite);

                throw new NullReferenceException();
            }
        }
    }
}
