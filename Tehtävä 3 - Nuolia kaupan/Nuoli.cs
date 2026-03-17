using System;

namespace Tehtävä_3___Nuolia_kaupan
{
    internal class Nuoli
    {
        private Kärki _kärki;
        private Sulat _sulat;
        private int _pituus;

        public Nuoli(Kärki kärki, Sulat sulat, int pituus)
        {
            if (pituus < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(pituus), "Pituus ei voi olla negatiivinen.");
            }

            _kärki = kärki;
            _sulat = sulat;
            _pituus = pituus;
        }

        public Kärki GetKärki() => _kärki;
        public Sulat GetSulat() => _sulat;
        public int GetPituus() => _pituus;
    }
}