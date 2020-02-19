using System;

namespace Oef
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //Sales test = new Sales();
            //test.rapport();
            Winkel winkel = new Winkel();//publisher
            Stockbeheer stock = new Stockbeheer(); //subscriber stock
            Sales sales = new Sales();//subscriber sales
            winkel.Verkoop += stock.OnVerkoop;
            winkel.Verkoop += sales.OnVerkoop;
            winkel.VerkoopProduct(new Bestelling(ProductType.Dubbel,4,3,"wathever"));
            sales.Rapport();
        }
    }
}
