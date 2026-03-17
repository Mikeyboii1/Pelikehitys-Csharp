namespace Tehtävä_2___Ruoka_annos_Generaattori
{
    class Ateria
    {
        // Ateria koostuu kolmesta aineksesta
        // Ne ovat private jotta niitä ei voi muuttaa aterian
        // luomisen jälkeen
        private PääRaakaAine pääaine;
        private Lisuke lisuke;
        private Kastike kastike;

        // Konstruktori määrää että uuden aterian voi luoda vain
        // jos antaa kaikki kolme ainesta
        public Ateria(PääRaakaAine pääaine, Lisuke lisuke, Kastike kastike)
        {
            // Tämän ateria olion pääaineeksi tulee parametrina
            // annettu pääaine: this. viittaa olioon
            this.pääaine = pääaine;
            this.lisuke = lisuke;
            this.kastike = kastike;
        }

        // Koska kastike on private, pitää tehdä funktio joka on public
        // jotta sen voi lukea
        public Kastike AnnaKastike()
        {
            return this.kastike;
        }

        // ToString auttaa aterian tulostamisessa.
        // Ohjelmoijan ei tarvitse muistaa mitä kaikkea ateriassa on
        // Jos/kun Ateria luokka muuttuu, tarvitsee tulostuskoodi muuttaa vain
        // tässä funktiossa
        public override string ToString()
        {
            return $"Pääraaka-aine: {pääaine}, lisuke: {lisuke}, kastike: {kastike}";
        }
    }
}