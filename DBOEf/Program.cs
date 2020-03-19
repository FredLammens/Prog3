using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;

namespace DBOEf
{
    class Program
    {
        static void Main(string[] args)
        {
            DbProviderFactories.RegisterFactory("sqlServer", SqlClientFactory.Instance);
            string conectionString = @"Data Source=DESKTOP-OF28PIK\SQLEXPRESS;Initial Catalog=exc;Integrated Security=True";
            DbProviderFactory sqlFactory = DbProviderFactories.GetFactory("sqlServer");
            AdresBeheer adresbeheer = new AdresBeheer(sqlFactory, conectionString);
            adresbeheer.AddGMLAdressesDB();
            AdresRequest req = new AdresRequest(sqlFactory, conectionString);
            //Straatnaam straattest = new Straatnaam(65927, "kkakak", new Gemeente(65927, "Gent"));
            //Adres test = new Adres(20, straattest, "20b", "2a", "45", "standaard", 9000, 12.45, 89.45);
            //adresbeheer.voegAdresToe(test);
            System.Console.WriteLine("-----------------------------------------------------------------------");
            System.Console.WriteLine("-----------------------------------------------------------------------");
            System.Console.WriteLine("adres van id : 2000000004");
            Adres adresRequestTest = req.GetAdres(2000000004);
            System.Console.WriteLine(adresRequestTest);
            System.Console.WriteLine("-----------------------------------------------------------------------");
            System.Console.WriteLine("Straatnamen van alle Gent alfabetisch gesorteerd :");
            List<Straatnaam> straatnamen = req.getStraatnamen("Gent");
            foreach (Straatnaam straatnaam in straatnamen)
            {
                System.Console.WriteLine(straatnaam);
            }
            System.Console.WriteLine("-----------------------------------------------------------------------");
            System.Console.WriteLine("Alle adressen die tot deze straatnaam met id 6 behoort :");
            List<Adres> adressen = req.getAdressenStraat(6);
            foreach (Adres adres in adressen)
            {
                System.Console.WriteLine(adres);
            }
            System.Console.WriteLine("-----------------------------------------------------------------------");
            System.Console.WriteLine("-----------------------------------------------------------------------");
        }
    }
}
