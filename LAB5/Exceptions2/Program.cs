using System;

namespace Exceptions2
{
    class Program
    {
        public class TooShortException : Exception
        {
            public TooShortException()
            {
            }
            public TooShortException(string message)
                : base(message)
            {
            }
            public TooShortException(string message, Exception innerException)
                : base(message, innerException)
            {
            }
        }
        public class TooLongException : Exception
        {
            public TooLongException()
            {
            }
            public TooLongException(string message)
                : base(message)
            {
            }
            public TooLongException(string message, Exception innerException)
                : base(message, innerException)
            {
            }
        }

        public class NullStringException : Exception
        {
            public NullStringException()
            {
            }
            public NullStringException(string message)
                : base(message)
            {
            }
            public NullStringException(string message, Exception innerException)
                : base(message, innerException)
            {
            }
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Enter some sentence below:");
            string sentence = Console.ReadLine();

            try
            {
                MakeSubstring(sentence);
            }
            catch (TooShortException exc1)
            {
                Console.WriteLine("{0}\n{1}", exc1.Message, exc1.StackTrace);
            }
            catch (TooLongException exc2)
            {
                Console.WriteLine("{0}\n{1}", exc2.Message, exc2.StackTrace);
            }
            catch (NullStringException exc3)
            {
                Console.WriteLine("{0}\n{1}", exc3.Message, exc3.StackTrace);
            }
        }

        public static void MakeSubstring(string sentence)
        {
            if ((sentence.Length < 20) && (sentence.Length > 0))
            {
                throw new TooShortException("Sentence too SHORT!");
            }
            else if (sentence.Length > 40)
            {
                throw new TooLongException("Sentence too LONG!");
            }
            else if (sentence == "")
            {
                throw new NullStringException("No sentence passed!");
            }
            else
            {
                Console.WriteLine("Sentence entered correctly!");
                string[] substring = sentence.Split(' ');

                Console.WriteLine("Words found in passed sentence:");
                foreach (var word in substring)
                {
                    Console.WriteLine(word);
                }
            }
        }
    }
}
