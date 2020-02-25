namespace Oef
{
    public class Bestelling
    {
        public ProductType Product { get; private set; }
        public double Prijs { get; private set; }
        public int Aantal { get; private set; }
        public string Adres { get; private set; }
        public Bestelling(ProductType product, double prijs, int aantal, string adres) => (Product, Prijs, Aantal, Adres) = (product, prijs, aantal, adres);
        // uitprobeersel van tuple vervangt :
        // public Bestelling(ProductType product, double prijs, int aantal, string adres)
        // {
        //  Product = product;
        //  Prijs = prijs;
        //  Aantal = aantal;
        //  Adres = adres;
        // }
    }
}
