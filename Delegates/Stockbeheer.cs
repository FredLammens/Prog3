using System;
using System.Collections.Generic;
using System.Text;

namespace Oef
{
    class Stockbeheer
    {
        int minimumgrens;
        Dictionary<ProductType, int> Stock = new Dictionary<ProductType, int>();
        public Stockbeheer(int minimum = 0)
        {
            Stock.Add(ProductType.Dubbel, 100);
            Stock.Add(ProductType.Kriek, 100);
            Stock.Add(ProductType.Pils, 100);
            Stock.Add(ProductType.Tripel, 100);
        }
        public void OnVerkoop(object source, WinkelEventArgs e) 
        {
            Stock[e.Bestelling.Product] = Stock[e.Bestelling.Product]-e.Bestelling.Aantal;
            Console.WriteLine("verkoop shit");
            if (Stock[e.Bestelling.Product] < minimumgrens)
            {

                Console.WriteLine($"Vul bij met {100 - Stock[e.Bestelling.Product] - e.Bestelling.Aantal}.");
            }
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
