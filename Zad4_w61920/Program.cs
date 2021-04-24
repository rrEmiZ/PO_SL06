// Zadanie 4

using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Zadanie4_w61920
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
    }



    class Program
    {
        static void Main(string[] args)
        {
            int wybor;
            var list = new List<Statistics>();

            
            using (var sr = new StreamReader("db.json"))
            {
                var line = sr.ReadToEnd();
                list = JsonConvert.DeserializeObject<List<Statistics>>(line);
            }

            // Roznica populacji dla Indii (1. polecenie zadania)
            var Population_India_1970 = list.Find(Statistics => Statistics.Country.Value == "India" && Statistics.Date == "1970");
            var Pupulation_India_2000 = list.Find(Statistics => Statistics.Country.Value == "India" && Statistics.Date == "2000");
            Console.WriteLine("Roznica populacji pomiedzy Indiami z lat 1970, a 2000 to: " + (Convert.ToInt32(Pupulation_India_2000.Value) - Convert.ToInt32(Population_India_1970.Value)));
            
            // Roznica populacji dla USA (2. polecenie zadania)
            var Population_USA_1965 = list.Find(Statistics => Statistics.Country.Value == "United States" && Statistics.Date == "1965");
            var Pupulation_USA_2010 = list.Find(Statistics => Statistics.Country.Value == "United States" && Statistics.Date == "2010");
            Console.WriteLine("Roznica populacji pomiedzy USA z lat 1965, a 2010 to: " + (Convert.ToInt32(Pupulation_USA_2010.Value) - Convert.ToInt32(Population_USA_1965.Value)));

            // Roznica populacji dla Chin (3. polecenie zadania)
            var Population_China_1980 = list.Find(Statistics => Statistics.Country.Value == "China" && Statistics.Date == "1980");
            var Pupulation_China_2018 = list.Find(Statistics => Statistics.Country.Value == "China" && Statistics.Date == "2018");
            Console.WriteLine("Roznica populacji pomiedzy Chinam z lat 1980, a 2018 to: " + (Convert.ToInt32(Pupulation_China_2018.Value) - Convert.ToInt32(Population_China_1980.Value)));

            // Switch case do 4, 5, 6 polecenia z zadania
            while (true)
            {
                Console.WriteLine("\nWybierz opcje: ");
                Console.WriteLine("0. Wyjscie z aplikacji.");
                Console.WriteLine("1. Wyswietl populacje kraju z podanego roku.");
                Console.WriteLine("2. Wyswietl roznice populacji z danego kraju na podanej przestrzeni lat.");
                Console.WriteLine("3. Procentowy wzrost populacji Indii, Chin oraz USA wzgledem poprzedniego do wskazanego roku.\n");
                Console.WriteLine("Wybor: ");
                wybor = Convert.ToInt32(Console.ReadLine());
                

                switch (wybor) {
                    case 0:
                        System.Environment.Exit(1);
                        break;
                    // Podstawowa kontrola błędu
                    case 1:
                        Console.WriteLine("Podaj nazwe kraju: ");
                        string Nazwa_kraju = Console.ReadLine();
                        Console.WriteLine("Podaj rok: ");
                        string Rok = Console.ReadLine(); 
                        var Populacja_Z_Wybor_Kraju_Roku_Z_Opcji_1 = list.Find(Statistics => Statistics.Country.Value == Nazwa_kraju && Statistics.Date == Rok);
                        Console.WriteLine("Populacja dla kraju: " + Nazwa_kraju + " z roku " + Rok + " wynosi: " + Populacja_Z_Wybor_Kraju_Roku_Z_Opcji_1.Value);
                        break;
                    case 2:
                        Console.WriteLine("Podaj nazwe kraju: ");
                        Nazwa_kraju = Console.ReadLine();
                        Console.WriteLine("Podaj przestrzen lat: \n 1.Rok: ");
                        Rok = Console.ReadLine();
                        Console.WriteLine("2.Rok: ");
                        string Rok2 = Console.ReadLine();
                        var Populacja_Dla_Danego_Kraju_Z_1Roku_Dla_Opcji2 = list.Find(Statistics => Statistics.Country.Value == Nazwa_kraju && Statistics.Date == Rok);
                        var Populacja_Dla_Danego_Kraju_Z_2Roku_Dla_Opcji2 = list.Find(Statistics => Statistics.Country.Value == Nazwa_kraju && Statistics.Date == Rok2);
                        Console.WriteLine("Roznica populacji kraju: " + Nazwa_kraju + " z lat: " + Rok + " oraz " + Rok2 + " wynosi: " + Math.Abs(((Convert.ToInt32(Populacja_Dla_Danego_Kraju_Z_2Roku_Dla_Opcji2.Value) - Convert.ToInt32(Populacja_Dla_Danego_Kraju_Z_1Roku_Dla_Opcji2.Value)))));
                        break;
                    case 3:
                        Console.WriteLine("Podaj rok: ");
                        Rok = Console.ReadLine();
                        int Poprzedni_Rok_Z_Opcji3 = Convert.ToInt32(Rok) - 1;
                        
                        // Wzrost procentowy dla populacji USA 
                        var Populacja_Dla_USA_Opcja3 = list.Find(Statistics => Statistics.Country.Value == "United States" && Statistics.Date == Rok);
                        var Populacja_Dla_USA_Rok_Poprzedni_Opcja3 = list.Find(Statistics => Statistics.Country.Value == "United States" && Statistics.Date == Poprzedni_Rok_Z_Opcji3.ToString());                      
                        Console.WriteLine("Procentowy wzrost dla USA z lat: " + Rok + " oraz " + Poprzedni_Rok_Z_Opcji3.ToString() + " wynosi: " + (Convert.ToDecimal(Populacja_Dla_USA_Opcja3.Value)-Convert.ToDecimal(Populacja_Dla_USA_Rok_Poprzedni_Opcja3.Value))/Convert.ToDecimal(Populacja_Dla_USA_Rok_Poprzedni_Opcja3.Value) + "%");

                        // Wzrost procentowy dla populacji USA 
                        var Populacja_Dla_Chin_Opcja3 = list.Find(Statistics => Statistics.Country.Value == "China" && Statistics.Date == Rok);
                        var Populacja_Dla_Chin_Rok_Poprzedni_Opcja3 = list.Find(Statistics => Statistics.Country.Value == "China" && Statistics.Date == Poprzedni_Rok_Z_Opcji3.ToString());
                        Console.WriteLine("Procentowy wzrost dla Chin z lat: " + Rok + " oraz " + Poprzedni_Rok_Z_Opcji3.ToString() + " wynosi: " + (Convert.ToDecimal(Populacja_Dla_Chin_Opcja3.Value) - Convert.ToDecimal(Populacja_Dla_Chin_Rok_Poprzedni_Opcja3.Value)) / Convert.ToDecimal(Populacja_Dla_Chin_Rok_Poprzedni_Opcja3.Value) + "%");

                        // Wzrost procentowy dla populacji USA 
                        var Populacja_Dla_Indii_Opcja3 = list.Find(Statistics => Statistics.Country.Value == "India" && Statistics.Date == Rok);
                        var Populacja_Dla_Indii_Rok_Poprzedni_Opcja3 = list.Find(Statistics => Statistics.Country.Value == "India" && Statistics.Date == Poprzedni_Rok_Z_Opcji3.ToString());
                        Console.WriteLine("Procentowy wzrost dla Indii z lat: " + Rok + " oraz " + Poprzedni_Rok_Z_Opcji3.ToString() + " wynosi: " + (Convert.ToDecimal(Populacja_Dla_Indii_Opcja3.Value) - Convert.ToDecimal(Populacja_Dla_Indii_Rok_Poprzedni_Opcja3.Value)) / Convert.ToDecimal(Populacja_Dla_Indii_Rok_Poprzedni_Opcja3.Value) + "%");

                        break;
                    default:
                        Console.WriteLine("Napotkany blad");
                        System.Environment.Exit(1);
                        break;

                }
            }
        }
    } 
}
