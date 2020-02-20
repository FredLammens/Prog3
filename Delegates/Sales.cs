using System;
using System.Collections.Generic;
using System.Linq;

namespace Oef
{
    class Sales
    {
        Dictionary<string, List<Bestelling>> Deals = new Dictionary<string, List<Bestelling>>(); //klant en lijst van bestellingen
        public void Rapport()
        {
            #region Test
            //List<Bestelling> bestellingskes =new List<Bestelling>() { new Bestelling(ProductType.Kriek, 2.2, 3, "tralalal" ),new Bestelling(ProductType.Pils,3.5,2,"kaka"),new Bestelling(ProductType.Tripel,2.6,6,"shablabaa")};  
            //Deals.Add("kaka", bestellingskes);
            //Deals.Add("pipi", bestellingskes);
            #endregion
            Console.WriteLine("-----------");
            Console.WriteLine("Sales - rapport");
            string tekst;
            for (int i = 0; i < Deals.Count; i++)
            {
                Console.WriteLine(Deals.ElementAt(i).Key);
                for (int j = 0; j < Deals.ElementAt(i).Value.Count; j++)
                {
                    var product = Deals.ElementAt(i).Value[j].Product;
                    var aantal = Deals.ElementAt(i).Value[j].Aantal;
                    tekst = product.ToString().PadRight(8) + aantal;
                    Console.WriteLine(tekst.PadLeft(tekst.Length + 3));
                }
            }
            Console.WriteLine("-----------");
        }
        public void OnVerkoop(object source, WinkelEventArgs e)
        {
            int i = 0;
            while (i < Deals.Count || i == -1)
            {
                if (e.Bestelling.Adres == Deals.ElementAt(i).Key)
                {
                    Deals.ElementAt(i).Value.Add(e.Bestelling);
                    i = -1;
                }
                i++;
            }
            if (i == Deals.Count)
            {
                List<Bestelling> bestellingskes = new List<Bestelling>() { e.Bestelling };
                Deals.Add(e.Bestelling.Adres, bestellingskes);
            }
            Console.WriteLine("rapporteer shit");
        }
    }
}
