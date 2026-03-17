using System;

namespace Tehtävä_6___Ruudukko_koordinaatisto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var a = new Koordinaatti(0, 0);
            var b = new Koordinaatti(1, 0);
            var c = new Koordinaatti(0, 1);
            var d = new Koordinaatti(1, 1);
            var e = new Koordinaatti(2, 0);

            Console.WriteLine($"Annettu kordinaatti {a} on kordinaatin {b} vieressä.");
            Console.WriteLine($"Annettu kordinaatti {a} on kordinaatin {c} vieressä.");
            Console.WriteLine($"Annettu kordinaatti {a} on kordinaatin {d} vieressä.");
            Console.WriteLine($"Annettu kordinaatti {b} on kordinaatin {e} vieressä.");
            Console.WriteLine($"Annettu kordinaatti {c} on kordinaatin {d} vieressä.");
        }
    }

    // Immutable value type representing a grid coordinate.
    public readonly struct Koordinaatti
    {
        public int X { get; }
        public int Y { get; }

        public Koordinaatti(int x, int y)
        {
            X = x;
            Y = y;
        }

        // Returns true if the coordinate is orthogonally adjacent to 'other'
        // (one of X or Y differs by exactly 1 while the other is equal).
        public bool IsAdjacentTo(Koordinaatti other)
        {
            return (Math.Abs(X - other.X) == 1 && Y == other.Y)
                   || (Math.Abs(Y - other.Y) == 1 && X == other.X);
        }

        public override string ToString() => $"({X}, {Y})";
    }
}