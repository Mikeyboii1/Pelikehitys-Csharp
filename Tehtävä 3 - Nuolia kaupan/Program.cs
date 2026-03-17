using System;

namespace Tehtävä_3___Nuolia_kaupan
{
    enum Kärki
    {
        puu,
        teräs,
        timantti
    }

    enum Sulat
    {
        lehti,
        kanansulka,
        kotkansulka
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Minkälainen kärki (puu, teräs, timantti)?:");
            string kärkiInput = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("Minkälaiset sulat (lehti, kanansulka, kotkansulka)?:");
            string sulkaInput = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("Nuolen pituus sentteinä (60-100):");
            if (!int.TryParse(Console.ReadLine(), out int pituus))
            {
                Console.WriteLine("Virhe: pituus ei ole kelvollinen numero.");
                return;
            }

            if (pituus < 60 || pituus > 100)
            {
                Console.WriteLine("Virhe: pituuden tulee olla välillä 60-100.");
                return;
            }

            if (!TryParseKärki(kärkiInput, out Kärki kärki))
            {
                Console.WriteLine("Virhe: tuntematon kärki. Käytä: puu, teräs tai timantti.");
                return;
            }

            if (!TryParseSulat(sulkaInput, out Sulat sulat))
            {
                Console.WriteLine("Virhe: tuntemattomat sulat. Käytä: lehti, kanansulka tai kotkansulka.");
                return;
            }

            // Use Nuoli class with private fields and getters
            var nuoli = new Nuoli(kärki, sulat, pituus);
            double hinta = LaskeHinta(nuoli.GetKärki(), nuoli.GetSulat(), nuoli.GetPituus());

            // Output as requested
            Console.WriteLine($"Tämän nuolen hinta on ({hinta:F2}) kultarahaa.");
        }

        private static bool TryParseKärki(string input, out Kärki kärki)
        {
            string norm = input.Trim().ToLowerInvariant();
            return norm switch
            {
                "puu" => Set(out kärki, Kärki.puu),
                "teräs" or "teras" => Set(out kärki, Kärki.teräs),
                "timantti" => Set(out kärki, Kärki.timantti),
                _ => Unset(out kärki)
            };
        }

        private static bool TryParseSulat(string input, out Sulat s)
        {
            string norm = input.Trim().ToLowerInvariant();
            return norm switch
            {
                "lehti" => Set(out s, Sulat.lehti),
                "kanansulka" or "kana" => Set(out s, Sulat.kanansulka),
                "kotkansulka" or "kotka" => Set(out s, Sulat.kotkansulka),
                _ => Unset(out s)
            };
        }

        private static double LaskeHinta(Kärki kärki, Sulat sulat, int pituus)
        {
            // Kärjet ja niiden arvot
            double hinta = kärki switch
            {
                Kärki.puu => 3.0,
                Kärki.teräs => 5.0,
                Kärki.timantti => 50.0,
                _ => 0.0
            };

            // Sulkien eri arvot
            hinta += sulat switch
            {
                Sulat.lehti => 0.0,
                Sulat.kanansulka => 1.0,
                Sulat.kotkansulka => 5.0,
                _ => 0.0
            };

            // Varsi: 0.05 kultarahaa per senttimetri
            hinta += pituus * 0.05;

            return hinta;
        }

        private static bool Set<T>(out T target, T value)
        {
            target = value;
            return true;
        }

        private static bool Unset<T>(out T target)
        {
            target = default!;
            return false;
        }
    }
}