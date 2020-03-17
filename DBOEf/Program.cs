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
            //adresbeheer.AddGMLAdressesDB();
            Straatnaam straattest = new Straatnaam(4, "kkakak", new Gemeente(45, "Gent"));
            Adres test = new Adres(20, straattest, "20b", "2a", "45", "standaard", 9000, 12.45, 89.45);
            adresbeheer.voegAdresToe(test);
        }
    }
}
