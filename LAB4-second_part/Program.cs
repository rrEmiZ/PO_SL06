using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace SL06_2
{
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

    public class Statistics
    {
        public Indicator Indicator { get; set; }
        public Country Country { get; set; }
        public string Value { get; set; }
        public string Decimal { get; set; }
        public string Date { get; set; }


        // metoda ma za zadanie odczytac i zdeserializowac dane z pliku json, a nastepnie zwrocic liste z tymi danymi
        public static List<Statistics> Odczytaj(List<Statistics> lista, string nazwaPliku)
        {
            using (var sr = new StreamReader(nazwaPliku))
            {
                var line = sr.ReadToEnd();

                lista = JsonConvert.DeserializeObject<List<Statistics>>(line);
            }
            return lista;
        }
    }

    class Program
    {
        public static void WybierzOpcje()
        {
            Console.WriteLine("Dokonaj wyboru z listy ponizej:");
            Console.WriteLine("1. Roznica populacji w Indiach pomiedzy 1970 a 2000");
            Console.WriteLine("2. Roznica populacji w USA pomiedzy 1965 a 2010");
            Console.WriteLine("3. Roznica populacji w Chinach pomiedzy 1980 a 2018");
            Console.WriteLine("4. Wybierz kraj i rok, zeby wyswietlic populacje");
            Console.WriteLine("5. Wybierz kraj i zakres lat, zeby wyswietlic roznice populacji");
            Console.WriteLine("6. Wybierz kraj i rok, zeby wyswietlic wzrost popuacji wzgledem poprzedniego");
            Console.WriteLine("Kazdy inny znak konczy dzialanie programu");
        }

        static void Main(string[] args)
        {
            int input;
            string countryName;
            string chosenYear;
            bool flag = true;
            int populationFirst = 0;
            int populationSecond = 0;
            string firstYear;
            string secondYear;
            float wzrostPopulacji = 0;


            string[] countryList = new string[] { "India", "United States", "China" };
            var list = new List<Statistics>();
            list = Statistics.Odczytaj(list, "db.json");


            do
            {
                WybierzOpcje();
                Console.Write("Wybor: ");
                input = Convert.ToInt32(Console.ReadLine());

                switch (input)
                {
                    case 1:
                        /*
                        Pozwalający sprawdzić ile wynosi różnica populacji
                        pomiędzy rokiem 1970 a 2000 dla Indii.
                        */
                        foreach (var item in list)
                        {
                            if (item.Country.Value == "India")
                            {
                                if (item.Date == "1970")
                                {
                                    populationFirst = Convert.ToInt32(item.Value);
                                }
                                else if (item.Date == "2000")
                                {
                                    populationSecond = Convert.ToInt32(item.Value);
                                }
                            }
                        }
                        Console.WriteLine($"Roznica populacji miedzy rokiem 2000 a 1970 w Indiach:\n" +
                            $"{populationFirst} - {populationSecond} = {populationSecond- populationFirst}");
                        Console.WriteLine();
                        break;

                    case 2:
                        /*
                        Pozwalający sprawdzić ile wynosi różnica populacji
                        pomiędzy rokiem 1965 a 2010 dla USA.
                        */
                        foreach (var item in list)
                        {
                            if (item.Country.Value == "United States")
                            {
                                if (item.Date == "1965")
                                {
                                    populationFirst = Convert.ToInt32(item.Value);
                                }
                                else if (item.Date == "2010")
                                {
                                    populationSecond = Convert.ToInt32(item.Value);
                                }
                            }
                        }
                        Console.WriteLine($"Roznica populacji miedzy rokiem 2010 a 1965 w USA:\n" +
                            $"{populationSecond} - {populationFirst} = {populationSecond - populationFirst}");
                        Console.WriteLine();
                        break;

                    case 3:
                        /*
                        Pozwalający sprawdzić ile wynosi różnica populacji
                        pomiędzy rokiem 1980 a 2018 dla Chin.
                        */
                        foreach (var item in list)
                        {
                            if (item.Country.Value == "China")
                            {
                                if (item.Date == "1980")
                                {
                                    populationFirst = Convert.ToInt32(item.Value);
                                    Console.WriteLine(populationFirst);
                                }
                                else if (item.Date == "2018")
                                {
                                    populationSecond = Convert.ToInt32(item.Value);
                                    Console.WriteLine(populationSecond);
                                }
                            }
                        }
                        Console.WriteLine($"Roznica populacji miedzy rokiem 2018 a 1980 w Chinach:\n" +
                            $"{populationSecond} - {populationFirst} = {populationSecond - populationFirst}");
                        Console.WriteLine();
                        break;

                    case 4:
                        /*
                        Pozwalający użytkownikowi na wybranie roku i kraju,
                        z którego populację chciałby wyświetlić.
                        */
                        do
                        {
                            Console.WriteLine("India, United States, China");
                            
                            Console.Write("Wybierz kraj z listy, wpisz dokladna nazwe: ");
                            countryName = Console.ReadLine();

                            foreach (var item in countryList)
                            {
                                if (item.Contains(countryName))
                                {
                                    flag = false;
                                }
                            }
                        } while (flag);

                        Console.Write("Wybierz rok: ");
                        chosenYear = Console.ReadLine();

                        foreach (var item in list)
                        {
                            if ((item.Country.Value == countryName) && (item.Date == chosenYear))
                            {
                                Console.WriteLine($"{countryName} - {item.Value} people in {chosenYear}");
                            }
                        }
                        break;

                    case 5:
                        /*
                        Pozwalający użytkownikowi na sprawdzenie różnicy populacji
                        dla wskazanego zakresu lat i kraju.
                        */
                        do
                        {
                            Console.WriteLine("India, United States, China");

                            Console.Write("Wybierz kraj z listy, wpisz dokladna nazwe: ");
                            countryName = Console.ReadLine();

                            foreach (var item in countryList)
                            {
                                if (item.Contains(countryName))
                                {
                                    flag = false;
                                }
                            }
                        } while (flag);

                        Console.Write("Wybierz rok, poczatek zakresu: ");
                        firstYear = Console.ReadLine();

                        Console.Write("Wybierz rok, koniec zakresu: ");
                        secondYear = Console.ReadLine();


                        foreach (var item in list)
                        {
                            if (item.Country.Value == countryName)
                            {
                                if (item.Date == firstYear)
                                {
                                    populationFirst = Convert.ToInt32(item.Value);
                                }
                                else if (item.Date == secondYear)
                                {
                                    populationSecond = Convert.ToInt32(item.Value);
                                }
                            }
                        }

                        Console.WriteLine($"{firstYear} to {secondYear} in {countryName }:" +
                                $"\n{populationSecond} - {populationFirst} = {populationSecond - populationFirst}");
                        Console.WriteLine();
                        break;

                    case 6:
                        /*
                        Pozwalający użytkownikowi na sprawdzenie procentowego wzrostu populacji 
                        dla każdego kraju względem roku poprzedniego do wskazanego
                        */
                        Console.Write("Wybierz rok: ");
                        chosenYear = Console.ReadLine();
                        var chosenYearMinusOne = (Convert.ToInt32(chosenYear) - 1).ToString();

                        foreach (var item in list)
                        {
                            if (item.Country.Value.Contains("India"))
                            {
                                if (item.Date.Contains(chosenYear))
                                {
                                    populationFirst = Convert.ToInt32(item.Value);
                                }
                                else if (item.Date.Contains(chosenYearMinusOne))
                                {
                                    populationSecond = Convert.ToInt32(item.Value);
                                }
                            }
                        }
                        wzrostPopulacji = ((float)populationSecond / (float)populationFirst) * 100;
                        Console.WriteLine($"Wzrost populacji pomiedzy {chosenYearMinusOne} i {chosenYear} w Indiach wyniosl {wzrostPopulacji}%");
                        Console.WriteLine();

                        foreach (var item in list)
                        {
                            if (item.Country.Value.Contains("United States"))
                            {
                                if (item.Date.Contains(chosenYear))
                                {
                                    populationFirst = Convert.ToInt32(item.Value);
                                }
                                else if (item.Date.Contains(chosenYearMinusOne))
                                {
                                    populationSecond = Convert.ToInt32(item.Value);
                                }
                            }
                        }
                        wzrostPopulacji = ((float)populationSecond / (float)populationFirst) * 100;
                        Console.WriteLine($"Wzrost populacji pomiedzy {chosenYearMinusOne} i {chosenYear} w USA wyniosl {wzrostPopulacji}%");
                        Console.WriteLine();

                        foreach (var item in list)
                        {
                            if (item.Country.Value.Contains("China"))
                            {
                                if (item.Date.Contains(chosenYear))
                                {
                                    populationFirst = Convert.ToInt32(item.Value);
                                }
                                else if (item.Date.Contains(chosenYearMinusOne))
                                {
                                    populationSecond = Convert.ToInt32(item.Value);
                                }
                            }
                        }
                        wzrostPopulacji = ((float)populationSecond / (float)populationFirst) * 100;
                        Console.WriteLine($"Wzrost populacji pomiedzy {chosenYearMinusOne} i {chosenYear} w Chinach wyniosl {wzrostPopulacji}%");
                        Console.WriteLine();

                        break;
                }
            } while ((input >= 1) && (input <= 6));
        }  // main END
    }
}
