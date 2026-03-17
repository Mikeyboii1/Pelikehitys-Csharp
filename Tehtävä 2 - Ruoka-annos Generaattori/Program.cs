namespace Tehtävä_2___Ruoka_annos_Generaattori
{
    enum PääRaakaAine
    {
        Lihaa,
        Tofua
    }
    enum Lisuke
    {
        Perunaa,
        Riisiä,
        Pastaa
    }
    enum Kastike
    {
        Pippuri,
        Soijakastike
    }

    internal partial class Program
    {
        static void Main(string[] args)
        {
            // Ateria ateria = new Ateria();
            Console.WriteLine("Pääraaka-aine (nautaa, kanaa, tofu):");
            string pääaine = Console.ReadLine();
            if (pääaine == "nautaa")
            {
                pääaine = PääRaakaAine.Lihaa.ToString();
            }
            else if (pääaine == "kanaa")
            {
                pääaine = PääRaakaAine.Lihaa.ToString();
            }
            else if (pääaine == "tofu")
            {
                pääaine = PääRaakaAine.Tofua.ToString();
            }
            else
            {
                Console.WriteLine("Virheellinen pääraaka-aine");
                return;
            }
            // lisuke valinta
            Console.WriteLine("Lisukeet (perunaa, riisiä, pastaa):");
            string lisuke = Console.ReadLine();
            if (lisuke == "perunaa")
            {
                lisuke = Lisuke.Perunaa.ToString();
            }
            else if (lisuke == "riisiä")
            {
                lisuke = Lisuke.Riisiä.ToString();
            }
            else if (lisuke == "pastaa")
            {
                lisuke = Lisuke.Pastaa.ToString();
            }
            else
            {
                Console.WriteLine("Virheellinen lisuke");
                return;
            }
            // kastike valinta
            Console.WriteLine("Kastikkeet (pippuri, soijakastike, chilli):");
            string kastike = Console.ReadLine();
            if (kastike == "pippuri")
            {
                kastike = Kastike.Pippuri.ToString();
            }
            else if (kastike == "soijakastike")
            {
                kastike = Kastike.Soijakastike.ToString();
            }
            else if (kastike == "chilli")
            {
                kastike = "Chilli";
            }
            else
            {
                Console.WriteLine("Virheellinen kastike");
                return;
            }
            Console.WriteLine($"{pääaine} ja {lisuke} {kastike}-kastikkeella.");
        }
    }
}