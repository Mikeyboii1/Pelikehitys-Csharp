using System;

namespace Tehtävä_3___Nuolia_kaupan
{
    internal class Nuoli
    {
        // Auto-properties replace the previous private fields.
        // Properties expose read access publicly and mutation only inside the class.
        public Kärki Kärki { get; private set; }
        public Sulat Sulat { get; private set; }
        public int Pituus { get; private set; }

        public Nuoli(Kärki kärki, Sulat sulat, int pituus)
        {
            if (pituus < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(pituus), "Pituus ei voi olla negatiivinen.");
            }

            Kärki = kärki;
            Sulat = sulat;
            Pituus = pituus;
        }

        // Legacy getter methods kept for compatibility with existing code.
        public Kärki GetKärki() => Kärki;
        public Sulat GetSulat() => Sulat;
        public int GetPituus() => Pituus;
    }
}