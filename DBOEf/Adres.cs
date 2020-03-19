namespace DBOEf
{
    class Adres
    {
        public Adres(int ID, Straatnaam straatnaam, string appartementnummer, string busnummer, string huisnummer,
            string huisnummerlabel, int locatieID, double x, double y)
        {
            this.ID = ID;
            this.straatnaam = straatnaam;
            this.appartementnummer = appartementnummer;
            this.busnummer = busnummer;
            this.huisnummer = huisnummer;
            this.huisnummerlabel = huisnummerlabel;
            this.locatie = new AdresLocatie(locatieID,x, y);
        }

        public override string ToString()
        {
            return $"{straatnaam}locatie = [{locatie.x}, {locatie.y}], ID = {ID}, " +
                $"appartementnummer = {appartementnummer}, busnummer = {busnummer}, " +
                $"huisnummer = {huisnummer}, huisnummerlabel = {huisnummerlabel}";
        }

        public int ID { get; private set; }
        public Straatnaam straatnaam { get; private set; }
        public string appartementnummer { get; private set; }
        public string busnummer { get; private set; }
        public string huisnummer { get; private set; }
        public string huisnummerlabel { get; private set; }
        public AdresLocatie locatie { get; private set; }
        public int postcode { get; private set; }
    }
}
