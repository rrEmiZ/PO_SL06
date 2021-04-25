using System;
using System.IO;

namespace LAB4_21_4_2021
{
    class Program
    {
        static void Main(string[] args)
        {
            // Napisz program pozwalający na zapisanie do pliku o wskazanej nazwie, nr albumu
            // osoby, która napisała program.
            string numerAlbumu;
            using (var sw = new StreamWriter("numer_albumu.txt"))
            {
                Console.WriteLine("Podaj numer albumu");
                numerAlbumu = Console.ReadLine();
                sw.WriteLine(numerAlbumu);
            }
            // Napisz program pozwalający na wczytanie zawartości pliku o wskazanej nazwie.
            using(var sr = new StreamReader("numer_albumu.txt"))
            {
                var line = sr.ReadLine();

                while (line != null)
                {
                    Console.WriteLine(line);
                    line = sr.ReadLine();
                }
            }

            // Napisz program wczytujący listę peseli z pliku pesels.txt, a następnie zaimplementuj
            // funkcję sprawdzającą, ile jest żeńskich peseli we wczytanym zbiorze.

            int numberOfWomen = 0;
            int numberOfMan = 0;
            int numberOfPeople = 0;

            using (var sr = new StreamReader("pesels.txt"))
            {
                string pesel = sr.ReadLine();

                while (pesel != null)
                {
                    if (pesel[9] % 2 == 0)
                    {
                        numberOfWomen++;
                    }
                    else if (pesel[9] % 2 != 0)
                    {
                        numberOfMan++;
                    }

                    numberOfPeople++;
                    Console.WriteLine(pesel);
                    pesel = sr.ReadLine();
                }
            }

            Console.WriteLine($"{numberOfWomen} - number of woman\n{numberOfMan} - number of man" +
                $"\n{numberOfPeople} - total number of people");
        }
    }
}
