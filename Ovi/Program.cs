namespace Tehtava_1_Ovi
{
    internal class Program
    {
        // Enum oven tilalle ja pelaajan toiminnoille
        enum OvenTila
        {
            Auki,
            Kiinni,
            Lukossa
        }
        // Numeroarvot varmistavat ett‰ voi muuntaa kokonaisluvuksi ja toisinp‰in
        enum Toiminto
        {

            Avaa = 0,
            Lukitse = 1,
            AvaaLukko = 2,
            Sulje = 3
        }
        static void Main(string[] args)
        {
            // Aseta oven alkutila ja kerro se pelaajalle
            OvenTila tila = OvenTila.Auki;
            while (true)
            {


                Console.WriteLine($"Ovi on {tila}.");


                // Listaa kaikki toiminnot ja pyyd‰ pelaajaa valitsemaan
                // niist‰ yksi.
                // Kysy uudestaan jos valinta ei kelpaa
                Toiminto valittu = Toiminto.Avaa; // Oletusarvo, joka korvataan
                string[] toiminnot = Enum.GetNames<Toiminto>();

                // TODO: Pelin p‰‰luuppi voisi alkaa jostain t‰st‰

                Console.WriteLine("Valitse toiminto.");
                for (int i = 0; i < toiminnot.Length; i++)
                {
                    Console.WriteLine($"{i + 1}: {toiminnot[i]}");
                }
                // Lue pelaajan valinta ja tulkitse se joksikin toiminnoksi
                bool valintaOk = false; // Oleta ett‰ vastaa v‰‰rin
                string vastaus = Console.ReadLine();
                for (int i = 0; i < toiminnot.Length; i++)
                {
                    // Vertaa vastausta kaikkiin toimintoihin
                    if (toiminnot[i].ToLower() == vastaus.ToLower()) // Muuta kirjainkoko samaksi
                    {
                        valittu = (Toiminto)i; // Muuta kokonaisluku enum arvoksi.
                        Console.WriteLine($"Valitsit {valittu}");
                        valintaOk = true;
                    }
                }

                switch (valittu)
                {
                    case Toiminto.Avaa: tila = Avaa(tila); break;
                    case Toiminto.Sulje: break;
                    case Toiminto.AvaaLukko: break;
                    case Toiminto.Lukitse: break;
                    default: break;
                }
                
                if (valintaOk == false)
                {
                    Console.WriteLine("Ep‰kelpo valinta");
                }
                // Tarkista voiko valitun toiminnon tehd‰?...
                // Jos ovi on Auki JA toiminto on Sulje
                if (tila == OvenTila.Auki && valittu == Toiminto.Sulje)
                {
                    // Sulje ovi
                    tila = OvenTila.Kiinni;
                }
                if (tila == OvenTila.Kiinni && valittu == Toiminto.Lukitse)
                {
                    // lukitse ovi
                    tila = OvenTila.Lukossa;
                }
                if (tila == OvenTila.Lukossa && valittu == Toiminto.AvaaLukko)
                {
                    // Avaa lukko
                    tila = OvenTila.Kiinni;
                }
                if (tila == OvenTila.Kiinni && valittu == Toiminto.Avaa)
                {
                    // Avaa ovi
                    tila = OvenTila.Auki;
                }
                
            }

            static OvenTila Avaa(OvenTila tila)
            {
                if (tila == OvenTila.Kiinni)
                    return OvenTila.Auki;

                Console.WriteLine("Ei k‰y j‰rkeen. Syy:");
                return tila;
            }

            static OvenTila Sulje(OvenTila tila)
            {
                if (tila == OvenTila.Auki)
                    return OvenTila.Kiinni;

                Console.WriteLine("Ei k‰y j‰rkeen. Syy:");
                return tila;
            }

            static OvenTila Lukitse(OvenTila tila)
            {
                if (tila == OvenTila.Kiinni)
                {
                    Console.WriteLine("Lukitsit oven");
                    return OvenTila.Lukossa;
                }

                if (tila == OvenTila.Lukossa) 
                {
                    Console.WriteLine("Ovi on jo lukittu");
                        return OvenTila.Lukossa;
                }

                if (tila == OvenTila.Kiinni)
                {
                    Console.WriteLine("Ovi on jo kiinni");
                    return OvenTila.Kiinni;
                }

                if (tila == OvenTila.Auki)
                {
                    Console.WriteLine("Ovi on jo Auki");
                    return OvenTila.Auki;
                }

                Console.WriteLine("Ei k‰y j‰rkeen. Syy:");
                return tila;
            }

            static OvenTila AvaaLukko(OvenTila tila)
            {
                if (tila == OvenTila.Lukossa)
                    return OvenTila.Kiinni;

                Console.WriteLine("Ei k‰y j‰rkeen.");
                return tila;
            }
            /* Kerro oven tila uudestaan ja kysy toimintoa uudestaan...
int r = 0;

// Tarkista kuoliko kumpikaan
while (true)
{
   // 
   Console.WriteLine($"Rivi " + r);
   Console.ReadLine();
   r += 1;
}
*/
        }
    }
}
