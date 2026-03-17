using System;

namespace Tehtävä_7___Väritetyt_tavarat
{
    public class Tavara
    {
        public override string ToString() => GetType().Name;
    }

    public class Miekka : Tavara { }

    public class Kirves : Tavara { }

    public class VaritettyTavara<T>
    {
        public T Tavara { get; }
        public ConsoleColor Vari { get; }

        public VaritettyTavara(T tavara, ConsoleColor vari)
        {
            Tavara = tavara ?? throw new ArgumentNullException(nameof(tavara));
            Vari = vari;
        }

        public void NaytaTavara()
        {
            var prev = Console.ForegroundColor;
            try
            {
                Console.ForegroundColor = Vari;
                Console.WriteLine(Tavara?.ToString());
            }
            finally
            {
                Console.ForegroundColor = prev;
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // Example 1: Treating the item as its base type
            Tavara testiMiekka = new Miekka();
            var tulimiekka = new VaritettyTavara<Tavara>(testiMiekka, ConsoleColor.Red);
            NaytaTavara(tulimiekka);

            // Example 2: Using the concrete type directly and calling the instance method
            Miekka toinenMiekka = new Miekka();
            var sininenMiekka = new VaritettyTavara<Miekka>(toinenMiekka, ConsoleColor.Blue);
            sininenMiekka.NaytaTavara();

            // Another example with a different item
            Kirves kirves = new Kirves();
            var keltainenKirves = new VaritettyTavara<Kirves>(kirves, ConsoleColor.Yellow);
            keltainenKirves.NaytaTavara();

            Console.ResetColor();
        }

        private static void NaytaTavara<T>(VaritettyTavara<T> vt)
        {
            if (vt == null) throw new ArgumentNullException(nameof(vt));
            var prev = Console.ForegroundColor;
            try
            {
                Console.ForegroundColor = vt.Vari;
                Console.WriteLine(vt.Tavara?.ToString());
            }
            finally
            {
                Console.ForegroundColor = prev;
            }
        }
    }
}