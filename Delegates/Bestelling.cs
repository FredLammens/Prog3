using System;
using System.Collections.Generic;
using System.Text;

namespace Oef
{
    public class Bestelling
    {
        public ProductType Product { get; private set; }
        public double Prijs { get; private set; }
        public int Aantal { get; private set; }
        public string Adres { get; private set; }
        public Bestelling(ProductType product,double prijs,int aantal,string adres)
        {
            this.Product = product;
            this.Prijs = prijs;
            this.Aantal = aantal;
            this.Adres = adres;
        }
    }
}
