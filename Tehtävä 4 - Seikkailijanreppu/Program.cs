using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Tehtävä_4___Seikkailijanreppu
{
    internal class Tavara
    {
        public double Paino { get; }
        public double Tilavuus { get; }

        public Tavara(double paino, double tilavuus)
        {
            if (paino < 0) throw new ArgumentOutOfRangeException(nameof(paino));
            if (tilavuus < 0) throw new ArgumentOutOfRangeException(nameof(tilavuus));
            Paino = paino;
            Tilavuus = tilavuus;
        }

        public override string ToString() => GetType().Name;
    }

    internal class Nuoli : Tavara { public Nuoli() : base(0.1, 0.05) { } }
    internal class Jousi : Tavara { public Jousi() : base(1.0, 4.0) { } }
    internal class Koysi : Tavara { public Koysi() : base(1.0, 1.5) { } }
    internal class Vesi : Tavara { public Vesi() : base(2.0, 2.0) { } }
    internal class RuokaAnnos : Tavara { public RuokaAnnos() : base(1.0, 0.5) { } }
    internal class Miekka : Tavara { public Miekka() : base(5.0, 3.0) { } }

    internal class Reppu
    {
        private readonly List<Tavara> _sisalto = new();

        public int MaxTavaroidenMaara { get; }
        public double MaxKantoPaino { get; }
        public double MaxTilavuus { get; }

        public Reppu(int maxMaara, double maxPaino, double maxTilavuus)
        {
            if (maxMaara < 0) throw new ArgumentOutOfRangeException(nameof(maxMaara));
            if (maxPaino < 0) throw new ArgumentOutOfRangeException(nameof(maxPaino));
            if (maxTilavuus < 0) throw new ArgumentOutOfRangeException(nameof(maxTilavuus));
            MaxTavaroidenMaara = maxMaara;
            MaxKantoPaino = maxPaino;
            MaxTilavuus = maxTilavuus;
        }

        public int TavaroidenMaara => _sisalto.Count;
        public double TavaroidenPaino => _sisalto.Sum(t => t.Paino);
        public double TavaroidenTilavuus => _sisalto.Sum(t => t.Tilavuus);

        public bool Lisää(Tavara tavara)
        {
            if (tavara == null) throw new ArgumentNullException(nameof(tavara));
            if (TavaroidenMaara + 1 > MaxTavaroidenMaara) return false;
            if (TavaroidenPaino + tavara.Paino > MaxKantoPaino) return false;
            if (TavaroidenTilavuus + tavara.Tilavuus > MaxTilavuus) return false;
            _sisalto.Add(tavara);
            return true;
        }

        public IReadOnlyList<Tavara> Sisalto => _sisalto;
    }

    internal class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Luo uusi reppu. Syötä repun kapasiteetit.");

            int maxCount = ReadInt("Maksimi tavaroiden määrä", 10);
            double maxWeight = ReadDouble("Maksimi kanto paino", 20.0);
            double maxVolume = ReadDouble("Maksimi tilavuus", 30.0);

            var reppu = new Reppu(maxCount, maxWeight, maxVolume);

            Func<Tavara>[] factories = {
                null!,
                () => new Nuoli(),
                () => new Jousi(),
                () => new Koysi(),
                () => new Vesi(),
                () => new RuokaAnnos(),
                () => new Miekka()
            };

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine($"Repussa on tällä hetkellä: {reppu.TavaroidenMaara}/{reppu.MaxTavaroidenMaara} tavaraa, paino {reppu.TavaroidenPaino:0.##}/{reppu.MaxKantoPaino:0.##}, tilavuus {reppu.TavaroidenTilavuus:0.##}/{reppu.MaxTilavuus:0.##}");
                Console.WriteLine();
                Console.WriteLine("Valitse lisättävä tavara:");
                Console.WriteLine("1 - Nuoli");
                Console.WriteLine("2 - Jousi");
                Console.WriteLine("3 - Köysi");
                Console.WriteLine("4 - Vesi");
                Console.WriteLine("5 - Ruoka-annos");
                Console.WriteLine("6 - Miekka");
                Console.WriteLine("7 - Listaa repun sisältö");
                Console.WriteLine("0 - Lopeta");
                Console.Write("Valinta: ");

                if (!int.TryParse(Console.ReadLine(), out int choice)) { Console.WriteLine("Virheellinen valinta."); continue; }

                if (choice == 0) break;

                if (choice == 7)
                {
                    if (reppu.Sisalto.Count == 0) Console.WriteLine("Reppu on tyhjä.");
                    else for (int i = 0; i < reppu.Sisalto.Count; i++) Console.WriteLine($"{i + 1} - {reppu.Sisalto[i]}");
                    continue;
                }

                if (choice < 1 || choice > 6) { Console.WriteLine("Tuntematon valinta."); continue; }

                var tavara = factories[choice]();
                if (reppu.Lisää(tavara)) Console.WriteLine($"{tavara} lisätty reppuun.");
                else Console.WriteLine("Tavaraa ei voitu lisätä (kapasiteetti ylittyy).");
            }

            Console.WriteLine("Ohjelma lopetetaan. Lopullinen repputilanne:");
            Console.WriteLine($"Repussa: {reppu.TavaroidenMaara}/{reppu.MaxTavaroidenMaara}, paino {reppu.TavaroidenPaino:0.##}/{reppu.MaxKantoPaino:0.##}, tilavuus {reppu.TavaroidenTilavuus:0.##}/{reppu.MaxTilavuus:0.##}");
        }

        private static int ReadInt(string prompt, int def)
        {
            while (true)
            {
                Console.Write($"{prompt} (oletus {def}): ");
                var s = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(s)) return def;
                if (int.TryParse(s.Trim(), out int v) && v >= 0) return v;
                Console.WriteLine("Anna kelvollinen positiivinen kokonaisluku.");
            }
        }

        private static double ReadDouble(string prompt, double def)
        {
            while (true)
            {
                Console.Write($"{prompt} (oletus {def.ToString(CultureInfo.InvariantCulture)}): ");
                var s = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(s)) return def;
                if (double.TryParse(s.Trim().Replace(',', '.'), NumberStyles.Float, CultureInfo.InvariantCulture, out double v) && v >= 0) return v;
                Console.WriteLine("Anna kelvollinen numero.");
            }
        }
    }
}