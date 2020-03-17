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
        }
    }
}
