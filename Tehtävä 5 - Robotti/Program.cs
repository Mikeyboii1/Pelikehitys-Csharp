using System;

namespace Tehtävä_5___Robotti
{
    public class Robotti
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool OnKäynnissä { get; set; }
        public IRobottiKäsky?[] Käskyt { get; } = new IRobottiKäsky?[3];

        public void Suorita()
        {
            foreach (IRobottiKäsky? käsky in Käskyt)
            {
                käsky?.Suorita(this);
                Console.WriteLine($"[{X} {Y} {OnKäynnissä}]");
            }
        }
    }

    public interface IRobottiKäsky
    {
        void Suorita(Robotti robotti);
    }

    public sealed class Käynnistä : IRobottiKäsky
    {
        public void Suorita(Robotti robotti) => robotti.OnKäynnissä = true;
    }

    public sealed class Sammuta : IRobottiKäsky
    {
        public void Suorita(Robotti robotti) => robotti.OnKäynnissä = false;
    }

    public sealed class YlösKäsky : IRobottiKäsky
    {
        public void Suorita(Robotti robotti)
        {
            if (!robotti.OnKäynnissä) return;
            robotti.Y += 1;
        }
    }

    public sealed class AlasKäsky : IRobottiKäsky
    {
        public void Suorita(Robotti robotti)
        {
            if (!robotti.OnKäynnissä) return;
            robotti.Y -= 1;
        }
    }

    public sealed class VasenKäsky : IRobottiKäsky
    {
        public void Suorita(Robotti robotti)
        {
            if (!robotti.OnKäynnissä) return;
            robotti.X -= 1;
        }
    }

    public sealed class OikeaKäsky : IRobottiKäsky
    {
        public void Suorita(Robotti robotti)
        {
            if (!robotti.OnKäynnissä) return;
            robotti.X += 1;
        }
    }

    internal class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            var robotti = new Robotti();

            Console.WriteLine("Syötä kolme käskyä robotille.");
            Console.WriteLine("Kelvolliset käskyt: käynnistä, sammuta, ylös, alas, vasen, oikea");

            int idx = 0;
            while (idx < robotti.Käskyt.Length)
            {
                Console.Write($"Käsky #{idx + 1}: ");
                string? input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input)) { Console.WriteLine("Tyhjä syöte, yritä uudelleen."); continue; }

                string key = input.Trim().ToLowerInvariant();
                key = key.Replace('ä', 'a').Replace('ö', 'o');

                IRobottiKäsky? käsky = key switch
                {
                    "kaynnista" or "käynnista" or "käynnistä" => new Käynnistä(),
                    "sammuta" => new Sammuta(),
                    "ylos" or "ylös" => new YlösKäsky(),
                    "alas" => new AlasKäsky(),
                    "vasen" => new VasenKäsky(),
                    "oikea" => new OikeaKäsky(),
                    _ => null
                };

                if (käsky is null)
                {
                    Console.WriteLine("Tuntematon käsky, yritä uudelleen.");
                    continue;
                }

                robotti.Käskyt[idx] = käsky;
                idx++;
            }

            Console.WriteLine();
            Console.WriteLine("Ajetaan käskyt:");
            robotti.Suorita();
        }
    }
}